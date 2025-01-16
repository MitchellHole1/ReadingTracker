using System.ComponentModel.DataAnnotations;
using MyReadingTracker.Models;

namespace MyReadingTracker.Resources.Requests.Books;

public class CreateBookRequest
{
    [Required]
    [MaxLength(100)]
    public string Name { get; init; }
    
    [Required]
    public required int AuthorId { get; init; }
    
    public int YearPublished { get; init; }
    public string OriginalLanguage { get; init; } = null!;
    public ICollection<int> Genres { get; init; } = new List<int>();
    public BookType Type { get; init; }
    
    public int Pages { get; init; }
}