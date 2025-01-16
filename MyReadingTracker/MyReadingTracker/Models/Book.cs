using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MyReadingTracker.Models.Base;
using TestDashboard.Domain.Models;

namespace MyReadingTracker.Models;

public class Book : AuditableEntity
{
    [MaxLength(100)]
    public required string Name { get; set; }
    
    [JsonIgnore]
    public int AuthorId { get; set; }
    
    public Author? Author { get; set; }
    
    public required int YearPublished { get; set; }
    
    public string? OriginalLanguage { get; set; }
    
    public ICollection<Genre>? Genres { get; set; }
    public ICollection<int>? GenreIds { get; set; }
    
    [JsonIgnore]
    public ICollection<ReadingSession>? ReadingSessions { get; set; }
    
    public BookType Type { get; set; }
    
    public int Pages { get; set; }
}
