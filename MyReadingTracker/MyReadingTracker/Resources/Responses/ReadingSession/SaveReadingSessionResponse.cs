using MyReadingTracker.Resources.Responses.Resources;

namespace MyReadingTracker.Resources.Responses.ReadingSession;

public class SaveReadingSessionResponse : BaseResponse
{
    public Models.ReadingSession? ReadingSession { get; private set; }
    
    private SaveReadingSessionResponse(bool success, string message, Models.ReadingSession readingSession) : base(success, message)
    {
        if (readingSession != null)
        {
            ReadingSession = readingSession;
        }
    }
    
    /// <summary>
    /// Creates a success response.
    /// </summary>
    /// <param name="category">Saved category.</param>
    /// <returns>Response.</returns>
    public SaveReadingSessionResponse(Models.ReadingSession readingSession) : this(true, string.Empty, readingSession)
    { }

    /// <summary>
    /// Creates am error response.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <returns>Response.</returns>
    public SaveReadingSessionResponse(string message) : this(false, message, null)
    { }
}