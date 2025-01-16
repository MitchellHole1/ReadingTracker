using Microsoft.EntityFrameworkCore;
using MyReadingTracker.Data;
using MyReadingTracker.Models;
using MyReadingTracker.Resources.Requests.Books;
using MyReadingTracker.Resources.Responses.Series;

namespace MyReadingTracker.Services;

public class SeriesService : ISeriesService
{
    private readonly LibraryContext _context;
    private readonly ILogger<SeriesService> _logger;
    
    public SeriesService(LibraryContext context, ILogger<SeriesService> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public IEnumerable<Series> GetAll()
    {
        return _context.Series
            .Include(p => p.Author)
            .Include(p => p.Books.OrderBy(b => b.YearPublished))
            .AsNoTracking()
            .ToList();    
    }

    public Series? GetById(int id)
    {
        return _context.Series
            .Include(p => p.Author)
            .Include(p => p.Books.OrderBy(b => b.YearPublished))
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == id);
    }
    
    public SaveSeriesResponse Save(CreateSeriesRequest request)
    {
        var author = _context.Authors.FirstOrDefault(a => a.Id == request.AuthorId);
        if (author == null)
        {
            _logger.LogError($"Author with id {request.AuthorId} not found");
            return new SaveSeriesResponse("Author not found");
        }
        
        var series = new Series
        {
            Name = request.Name,
            Author = author,
            Books = request.BookIds?.Select(id => _context.Books.FirstOrDefault(b => b.Id == id)).ToList()
        };
        
        _context.Series.Add(series);
        _context.SaveChanges();
        
        return new SaveSeriesResponse(series);
    }
    
}