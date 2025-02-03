namespace MyReadingTracker.Resources.Requests.Books;

public record GetBooksRequest : PaginatedQuery
{
    public string? SearchTerm { get; init; }
}