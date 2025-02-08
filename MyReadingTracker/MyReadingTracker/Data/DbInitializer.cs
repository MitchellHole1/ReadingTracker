using MyReadingTracker.Models;

namespace MyReadingTracker.Data;

public static class DbInitializer
{
    public static void Initialize(LibraryContext context)
    {
        if (context.Books.Any())
        {
            return;   // DB has been seeded
        }
        
        // seed Author row data for Cormac McCarthy
        var genre1 = new Genre { Name = "Western" };
        var genre2 = new Genre { Name = "Historical" };
        var genre3 = new Genre { Name = "Fantasy" };
        var genre4 = new Genre { Name = "Science Fiction" };
        var genre5 = new Genre { Name = "Mystery/Thriller" };
        var genre6 = new Genre { Name = "Horror" };
        var genre7 = new Genre { Name = "Romance" };
        var genre8 = new Genre { Name = "Non-Fiction" };
        
        var author1 = new Author { Name = "Cormac McCarthy", Gender = Gender.Male, Nationality = "American" };
        var author2 = new Author { Name = "J.R.R. Tolkien", Gender = Gender.Male, Nationality = "British" };
        var author3 = new Author { Name = "Adrian Tchaikovsky", Gender = Gender.Male, Nationality = "British" };

        var authors = new List<Author>
        {
            new Author { Name = "George Orwell", Gender = Gender.Male, Nationality = "British" },
            new Author { Name = "Jane Austen", Gender = Gender.Female, Nationality = "British" },
            new Author { Name = "Mark Twain", Gender = Gender.Male, Nationality = "American" },
            new Author { Name = "J.K. Rowling", Gender = Gender.Female, Nationality = "British" },
            new Author { Name = "Albert Camus", Gender = Gender.Male, Nationality = "French" },
            new Author { Name = "Chimamanda Ngozi Adichie", Gender = Gender.Female, Nationality = "Nigerian" },
            new Author { Name = "Haruki Murakami", Gender = Gender.Male, Nationality = "Japanese" },
            new Author { Name = "Maya Angelou", Gender = Gender.Female, Nationality = "American" },
            new Author { Name = "Toni Morrison", Gender = Gender.Female, Nationality = "American" },
            new Author { Name = "Leo Tolstoy", Gender = Gender.Male, Nationality = "Russian" },
            new Author { Name = "Franz Kafka", Gender = Gender.Male, Nationality = "Austrian" },
            new Author { Name = "Gabriel García Márquez", Gender = Gender.Male, Nationality = "Colombian" },
            new Author { Name = "Virginia Woolf", Gender = Gender.Female, Nationality = "British" },
            new Author { Name = "F. Scott Fitzgerald", Gender = Gender.Male, Nationality = "American" },
            new Author { Name = "Harper Lee", Gender = Gender.Female, Nationality = "American" },
            new Author { Name = "Fyodor Dostoevsky", Gender = Gender.Male, Nationality = "Russian" },
            new Author { Name = "Isabel Allende", Gender = Gender.Female, Nationality = "Chilean" },
            new Author { Name = "Neil Gaiman", Gender = Gender.Male, Nationality = "British" },
            new Author { Name = "Daphne du Maurier", Gender = Gender.Female, Nationality = "British" }
        };
        

        var book1 = new Book { Name = "Blood Meridian", Pages = 351, Author = author1, YearPublished = 1985, OriginalLanguage = "English", Type = BookType.Novel, Genres = new List<Genre> { genre1, genre2 } };
        var book2 = new Book { Name = "The Road", Pages = 241, Author = author1, YearPublished = 2006, OriginalLanguage = "English", Type = BookType.Novel };
        var book3 = new Book { Name = "Suttree", Pages = 471, Author = author1, YearPublished = 1979, OriginalLanguage = "English", Type = BookType.Novel, Genres = new List<Genre> { genre2 }};
        var book4 = new Book { Name = "No Country for Old Men", Pages  = 309, Author = author1, YearPublished = 2005, OriginalLanguage = "English", Type = BookType.Novel };
        var book5 = new Book { Name = "The Hobbit", Pages = 366, Author = author2, YearPublished = 1937, OriginalLanguage = "English", Type = BookType.Novel, Genres = new List<Genre> { genre3 } };
        var book6 = new Book { Name = "The Fellowship of the Ring", Pages = 432, Author = author2, YearPublished = 1954, OriginalLanguage = "English", Type = BookType.Novel, Genres = new List<Genre> { genre3 } };
        var book7 = new Book { Name = "The Two Towers", Pages = 448, Author = author2, YearPublished = 1954, OriginalLanguage = "English", Type = BookType.Novel, Genres = new List<Genre> { genre3 } };
        var book8 = new Book { Name = "The Return of the King", Pages = 432, Author = author2, YearPublished = 1955, OriginalLanguage = "English", Type = BookType.Novel, Genres = new List<Genre> { genre3 } };
        var book9 = new Book { Name = "Days of Shattered Faith", Pages = 600, Author = author3, YearPublished = 1955, OriginalLanguage = "English", Type = BookType.Novel, Genres = new List<Genre> { genre3 } };
        var readingSession1 = new ReadingSession { Book = book1, Start = new DateTime(2023, 1, 1).ToUniversalTime(), End = new DateTime(2023, 1, 31).ToUniversalTime(), Rating = 100 };
        var readingSession2 = new ReadingSession { Book = book3, Start = new DateTime(2024, 2, 1).ToUniversalTime(), End = new DateTime(2024, 2, 28).ToUniversalTime(), Rating = 100 };
        var readingSession3 = new ReadingSession { Book = book9, Start = new DateTime(2025, 1, 29).ToUniversalTime(), End = null, Rating = null};
        var readingSession4 = new ReadingSession { Book = book5, Start = new DateTime(2025, 1, 29).ToUniversalTime(), End = null, Rating = null};
        var series1 = new Series { Name = "The Lord of the Rings", Author = author2, Books = new List<Book> { book5, book6, book7, book8 } };
        context.Genres.AddRange(genre1, genre2, genre3, genre4, genre5, genre6, genre7, genre8);
        context.Books.AddRange(book1, book2, book3, book4);
        context.ReadingSessions.AddRange(readingSession1, readingSession2, readingSession3, readingSession4);
        context.Series.Add(series1);
        context.Authors.AddRange(authors);
        context.SaveChanges();
    }
}