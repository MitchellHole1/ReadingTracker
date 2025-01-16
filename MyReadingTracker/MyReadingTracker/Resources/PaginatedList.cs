using Microsoft.EntityFrameworkCore;

namespace MyReadingTracker.Resources;

public class PaginatedList<T>
{
    public IReadOnlyCollection<T> Results { get; }
    public int Offset { get; }
    public int Limit { get; }
    public int Total { get; }

    public PaginatedList(IReadOnlyCollection<T> items, int count, int pageNumber, int pageSize)
    {
        Offset = (pageNumber - 1) * pageSize;
        Limit = pageSize;
        Total = count;
        Results = items;
    }

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PaginatedList<T>(items, count, pageNumber, pageSize);
    }
}