using System.Text.Json.Serialization;
using MyReadingTracker.Models.Base;
using TestDashboard.Domain.Models;

namespace MyReadingTracker.Models;

public class Author : AuditableEntity
{
    public required string Name { get; set; }
    
    public required Gender Gender { get; set; }
    
    public string? Nationality { get; set; }
    
    [JsonIgnore]
    public ICollection<Book>? BooksAuthored { get; set; }
}

public enum Gender
{
    Male,
    Female,
    Other
}