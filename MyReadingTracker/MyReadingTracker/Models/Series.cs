using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MyReadingTracker.Models.Base;

namespace MyReadingTracker.Models;

public class Series : AuditableEntity
{
    public required string Name { get; set; }
    
    [JsonIgnore]
    public int AuthorId { get; set; }
    
    public Author? Author { get; set; }
    
    public ICollection<Book>? Books { get; set; }
}