using Microsoft.EntityFrameworkCore;
using MyReadingTracker.Data;
using MyReadingTracker.Models;
using MyReadingTracker.Resources;
using MyReadingTracker.Resources.Requests.Books;
using MyReadingTracker.Resources.Responses.Author;
using MyReadingTracker.Resources.Responses.Resources;

namespace MyReadingTracker.Services;

public class AuthorService : IAuthorService
{
    private readonly LibraryContext _context;
    private readonly ILogger<AuthorService> _logger;
    
    public AuthorService(LibraryContext context, ILogger<AuthorService> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public PaginatedList<Author> GetAll(GetAuthorRequest request)
    {
        var authors = _context.Authors
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize)
            .ToList();
        
        return new PaginatedList<Author>(authors, _context.Authors.Count(), request.PageNumber, request.PageSize);
    }

    public Author? GetById(int id)
    {
        return _context.Authors
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == id);
    }
    
    public IEnumerable<Book> GetBooksByAuthorId(int authorId)
    {
        
        return _context.Books
            .Include(p => p.Genres)
            .AsNoTracking()
            .Where(p => p.AuthorId == authorId)
            .ToList();
    }
    
    public SaveAuthorResponse Create(Author newAuthor)
    {
        try
        {
            _logger.LogInformation("Creating a new author.");
            _context.Authors.Add(newAuthor);
            _context.SaveChanges();
        
            return new SaveAuthorResponse(newAuthor);
        }
        catch (Exception ex)
        {
            return new SaveAuthorResponse($"An error occurred when saving the author: {ex.Message}");
        }
    }
}