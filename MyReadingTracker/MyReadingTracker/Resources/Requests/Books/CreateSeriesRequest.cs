using System.ComponentModel.DataAnnotations;

namespace MyReadingTracker.Resources.Requests.Books;

public class CreateSeriesRequest
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    public int AuthorId { get; set; }
    
    public ICollection<int>? BookIds { get; set; }
}