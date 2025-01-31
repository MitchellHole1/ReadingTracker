using FluentAssertions;
using MyReadingTracker.Models;

namespace Tests;

public class BookModelUnitTests
{
    [Fact]
    public void Test_BookModel()
    {
        // Arrange
        var book = new Book
        {
            Id = 1,
            Name = "The Hobbit",
            AuthorId = 1,
            YearPublished = 1937
        };

        // Act

        // Assert
        book.Id.Should().Be(1);
        book.Name.Should().Be("The Hobbit");
        book.AuthorId.Should().Be(1);
        book.YearPublished.Should().Be(1937);
        book.GenreIds.Should().BeEmpty();
    }

    [Fact]
    public void Test_BookModel_WithDefaultValues()
    {
        // Arrange
        var book = new Book
        {
            Name = "The Hobbit",
            YearPublished = 1937
        };

        // Act

        // Assert
        book.Id.Should().Be(0);
        book.Name.Should().Be("The Hobbit");
        book.YearPublished.Should().Be(0);
        book.GenreIds.Should().BeEmpty();
    }
}