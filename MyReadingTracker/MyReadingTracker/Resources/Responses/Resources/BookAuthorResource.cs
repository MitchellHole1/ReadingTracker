using MyReadingTracker.Models;

namespace MyReadingTracker.Resources.Responses.Resources;

public class BookAuthorResource : BookResource
{
    public Models.Author Author { get; set; }
}