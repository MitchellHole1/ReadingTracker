using Microsoft.EntityFrameworkCore;
using MyReadingTracker.Data;
using MyReadingTracker.Models;
using MyReadingTracker.Resources.Requests.Books;
using MyReadingTracker.Resources.Responses;
using MyReadingTracker.Resources.Responses.Book;

namespace MyReadingTracker.Services;

public class BookService : IBookService
{
    private readonly LibraryContext _context;
    private readonly ILogger<BookService> _logger;
    
    public BookService(LibraryContext context, ILogger<BookService> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public IEnumerable<Book> GetAll()
    {
        return _context.Books
            .Include(p => p.Author)
            .Include(p => p.Genres)
            .OrderBy(p => p.Author.Name)
            .ThenBy(p => p.Name)
            .AsNoTracking()
            .ToList();    
    }

    public Book? GetById(int id)
    {
        return _context.Books
            .Include(p => p.Author)
            .Include(p => p.Genres)
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == id);
    }
    
    public SaveBookResponse Create(CreateBookRequest newBook)
    {
        try
        {
            _logger.LogInformation("Creating a new book.");
            var existAuthor = _context.Authors.Find(newBook.AuthorId);
            if (existAuthor is null)
            {
                _logger.LogWarning("Author not found.");
                return new SaveBookResponse("Author not found.");
            }
            foreach (var genreId in newBook.Genres)
            {
                var existGenre = _context.Genres.Find(genreId);
                if (existGenre is null)
                {
                    _logger.LogWarning("Genre not found.");
                    return new SaveBookResponse("Genre not found.");
                }
            }
            
            var genres = _context.Genres.Where(genre => newBook.Genres.Contains(genre.Id)).ToList();
            
            var bookToAdd = new Book
            {
                Name = newBook.Name,
                AuthorId = newBook.AuthorId,
                YearPublished = newBook.YearPublished,
                OriginalLanguage = newBook.OriginalLanguage,
                Genres = genres,
                Type = newBook.Type,
                Pages = newBook.Pages
            };
            
            _context.Books.Add(bookToAdd);
            _context.SaveChanges();
        
            return new SaveBookResponse(bookToAdd);
        }
        catch (Exception ex)
        {
            return new SaveBookResponse($"An error occurred when saving the book: {ex.Message}");
        }
    }
    
    public void Update(Book updatedBook)
    {
        _context.Books.Update(updatedBook);
        _context.SaveChanges();
    }
    
    public void DeleteById(int id) 
    {
        var book = _context.Books.Find(id);
        if(book is not null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}