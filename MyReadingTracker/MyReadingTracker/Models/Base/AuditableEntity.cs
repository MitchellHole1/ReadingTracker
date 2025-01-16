using System.Text.Json.Serialization;
using TestDashboard.Domain.Models;

namespace MyReadingTracker.Models.Base;

public abstract class AuditableEntity : Entity
{
    [JsonIgnore]
    public DateTime Created { get; set; }

    [JsonIgnore]
    public string? CreatedBy { get; set; }
    
    [JsonIgnore]
    public DateTime? LastModified { get; set; }
    
    [JsonIgnore]
    public string? LastModifiedBy { get; set; }
}