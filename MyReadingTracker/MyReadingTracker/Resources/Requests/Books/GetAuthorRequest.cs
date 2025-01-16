namespace MyReadingTracker.Resources.Requests.Books;

public record GetAuthorRequest : PaginatedQuery
{
    public string? SearchTerm { get; init; }
}