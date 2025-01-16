using MyReadingTracker.Models;
using MyReadingTracker.Resources.Responses.Resources;

namespace MyReadingTracker.Resources.Responses.Author;

public class SaveAuthorResponse : BaseResponse
{
    public Models.Author? Author { get; private set; }
    
    private SaveAuthorResponse(bool success, string message, Models.Author author) : base(success, message)
    {
        if (author != null)
        {
            Author = author;
        }
    }
    
    /// <summary>
    /// Creates a success response.
    /// </summary>
    /// <param name="category">Saved category.</param>
    /// <returns>Response.</returns>
    public SaveAuthorResponse(Models.Author author) : this(true, string.Empty, author)
    { }

    /// <summary>
    /// Creates am error response.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <returns>Response.</returns>
    public SaveAuthorResponse(string message) : this(false, message, null)
    { }
    
}