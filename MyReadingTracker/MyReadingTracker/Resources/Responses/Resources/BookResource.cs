using MyReadingTracker.Models;

namespace MyReadingTracker.Resources.Responses.Resources;

public class BookResource
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int YearPublished { get; set; }
    public string OriginalLanguage { get; set; } = null!;
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    public BookType Type { get; set; }
    
    public int Pages { get; set; }
}