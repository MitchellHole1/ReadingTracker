namespace MyReadingTracker.Resources.Requests;

public abstract record PaginatedQuery
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}