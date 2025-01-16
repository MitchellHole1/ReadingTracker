namespace MyReadingTracker.Resources.Requests.Books;

public class UpdateReadingSessionRequest
{
    public int Rating { get; init; }

    public DateTime? Start { get; set; }
    
    public DateTime? End { get; set; }
}