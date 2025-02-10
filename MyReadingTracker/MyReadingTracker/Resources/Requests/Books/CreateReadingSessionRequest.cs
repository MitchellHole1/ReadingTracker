using System.ComponentModel.DataAnnotations;

namespace MyReadingTracker.Resources.Requests.Books;

public class CreateReadingSessionRequest
{
    [Required]
    public required int BookId { get; init; }
    
    [Range(0, 100)]
    public int Rating { get; init; }

    public DateTime? Start { get; set; }
    
    public DateTime? End { get; set; }
}