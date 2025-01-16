using Microsoft.EntityFrameworkCore;
using MyReadingTracker.Data;
using MyReadingTracker.Models;

namespace MyReadingTracker.Services;

public class GenreService : IGenreService
{
    private readonly LibraryContext _context;
    private readonly ILogger<GenreService> _logger;
    
    public GenreService(LibraryContext context, ILogger<GenreService> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public IEnumerable<Genre> GetAll()
    {
        return _context.Genres
            .AsNoTracking()
            .OrderBy(genre => genre.Name)
            .ToList();
    }
}