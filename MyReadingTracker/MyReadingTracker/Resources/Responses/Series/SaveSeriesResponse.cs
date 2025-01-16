namespace MyReadingTracker.Resources.Responses.Series;

public class SaveSeriesResponse : BaseResponse
{
    public Models.Series? Series { get; private set; }
    
    private SaveSeriesResponse(bool success, string message, Models.Series series) : base(success, message)
    {
        if (series != null)
        {
            Series = series;
        }
    }
    
    /// <summary>
    /// Creates a success response.
    /// </summary>
    /// <param name="category">Saved category.</param>
    /// <returns>Response.</returns>
    public SaveSeriesResponse(Models.Series series) : this(true, string.Empty, series)
    { }

    /// <summary>
    /// Creates am error response.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <returns>Response.</returns>
    public SaveSeriesResponse(string message) : this(false, message, null)
    { }
}