using System.ComponentModel.DataAnnotations;
using MyReadingTracker.Models.Base;
using TestDashboard.Domain.Models;

namespace MyReadingTracker.Models;

public class ReadingSession : AuditableEntity
{
    public int BookId { get; set; }
    public required Book Book { get; set; }
    
    public DateTime? Start { get; set; } = null!;
    
    public DateTime? End { get; set; } = null!;
    
    [Range(0, 100)]
    public int? Rating { get; set; }
}