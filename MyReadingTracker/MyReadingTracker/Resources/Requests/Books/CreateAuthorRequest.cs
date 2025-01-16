using System.ComponentModel.DataAnnotations;
using MyReadingTracker.Models;

namespace MyReadingTracker.Resources.Requests.Books;

public class CreateAuthorRequest
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    public required Gender Gender { get; set; }
    
    public string? Nationality { get; set; }
}