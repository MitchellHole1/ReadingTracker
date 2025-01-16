using System.Text.Json.Serialization;
using MyReadingTracker.Models.Base;
using TestDashboard.Domain.Models;

namespace MyReadingTracker.Models;

public class Genre : AuditableEntity
{
    public required string Name { get; set; }
    
    [JsonIgnore]
    public ICollection<Book>? Books { get; set; }
}