using Microsoft.EntityFrameworkCore;
using MyReadingTracker.Models;

namespace MyReadingTracker.Data;

public class LibraryContext : DbContext
{
    public LibraryContext (DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }
    
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<ReadingSession> ReadingSessions => Set<ReadingSession>();
    public DbSet<Series> Series => Set<Series>();
}