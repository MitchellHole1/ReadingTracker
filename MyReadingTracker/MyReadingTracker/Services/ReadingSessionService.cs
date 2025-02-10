using Microsoft.EntityFrameworkCore;
using MyReadingTracker.Data;
using MyReadingTracker.Models;
using MyReadingTracker.Resources.Requests.Books;
using MyReadingTracker.Resources.Responses.ReadingSession;

namespace MyReadingTracker.Services;

public class ReadingSessionService : IReadingSessionService
{
    private readonly LibraryContext _context;
    private readonly ILogger<ReadingSessionService> _logger;
    
    public ReadingSessionService(LibraryContext context, ILogger<ReadingSessionService> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public IEnumerable<ReadingSession> GetAll()
    {
        return _context.ReadingSessions
            .AsNoTracking()
            .Include(readingSession => readingSession.Book)
            .ThenInclude(book => book.Author)
            .Where(readingSession => readingSession.End != null)
            .OrderByDescending(readingSession => readingSession.End)
            .ToList();
    }

    public IEnumerable<ReadingSession> GetCurrentReadings()
    {
        return _context.ReadingSessions
            .AsNoTracking()
            .Include(readingSession => readingSession.Book)
            .ThenInclude(book => book.Author)
            .Where(readingSession => readingSession.End == null)
            .OrderByDescending(readingSession => readingSession.Start)
            .ToList();
    }
    
    public ReadingSession? GetById(int id)
    {
        return _context.ReadingSessions
            .AsNoTracking()
            .Include(readingSession => readingSession.Book)
            .ThenInclude(book => book.Author)
            .SingleOrDefault(readingSession => readingSession.Id == id);
    }
    
    public SaveReadingSessionResponse Create(ReadingSession newReadingSession)
    {
        try
        {
            _logger.LogInformation("Creating a new reading session.");

            if (newReadingSession.Start > newReadingSession.End)
            {
                _logger.LogWarning("Start date is after end date.");
                return new SaveReadingSessionResponse("Start date is after end date.");
            }
            
            var existBook = _context.Books.Find(newReadingSession.BookId);
            if (existBook is null)
            {
                _logger.LogWarning("Book not found.");
                return new SaveReadingSessionResponse("Book not found.");
            }
            
            _context.ReadingSessions.Add(newReadingSession);
            _context.SaveChanges();
        
            return new SaveReadingSessionResponse(newReadingSession);
        }
        catch (Exception ex)
        {
            return new SaveReadingSessionResponse($"An error occurred when saving the reading session: {ex.Message}");
        }
    }
    
    public SaveReadingSessionResponse Update(int id, UpdateReadingSessionRequest updatedReadingSession)
    {
        try
        {
            _logger.LogInformation("Updating reading session.");
            var readingSession = _context.ReadingSessions.Find(id);
            if (readingSession is null)
            {
                _logger.LogWarning("Reading session not found.");
                return new SaveReadingSessionResponse("Reading session not found.");
            }
            
            readingSession.Start = updatedReadingSession.Start;
            readingSession.End = updatedReadingSession.End;
            readingSession.Rating = updatedReadingSession.Rating;
            
            _context.ReadingSessions.Update(readingSession);
            _context.SaveChanges();
            
            return new SaveReadingSessionResponse(readingSession);
        }
        catch (Exception ex)
        {
            return new SaveReadingSessionResponse($"An error occurred when updating the reading session: {ex.Message}");
        }
    }
}