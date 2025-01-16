using MyReadingTracker.Resources.Responses.Resources;

namespace MyReadingTracker.Resources.Responses.Book;

public class SaveBookResponse : BaseResponse
{
    public BookAuthorResource? BookResource { get; private set; }
    
    private SaveBookResponse(bool success, string message, Models.Book book) : base(success, message)
    {
        if (book != null)
        {
            BookResource = new BookAuthorResource
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                YearPublished = book.YearPublished,
                OriginalLanguage = book.OriginalLanguage,
                Genres = book.Genres,
                Type = book.Type,
                Pages = book.Pages
            };
        }
    }
    
    /// <summary>
    /// Creates a success response.
    /// </summary>
    /// <param name="category">Saved category.</param>
    /// <returns>Response.</returns>
    public SaveBookResponse(Models.Book book) : this(true, string.Empty, book)
    { }

    /// <summary>
    /// Creates am error response.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <returns>Response.</returns>
    public SaveBookResponse(string message) : this(false, message, null)
    { }
}