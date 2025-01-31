using FluentAssertions;
using MyReadingTracker.Models;

namespace Tests;

public class AuthorModelUnitTests
{
    [Fact]
    public void Test_AuthorModel()
    {
        // Arrange
        var author = new Author
        {
            Id = 1,
            Name = "J.R.R. Tolkien",
            Gender = Gender.Male,
            Nationality = "British"
        };

        // Act

        // Assert
        author.Id.Should().Be(1);
        author.Name.Should().Be("J.R.R. Tolkien");
        author.Gender.Should().Be(Gender.Male);
        author.Nationality.Should().Be("British");
    }

    [Fact]
    public void Test_AuthorModel_WithDefaultValues()
    {
        // Arrange
        var author = new Author {
            Name = "J.R.R. Tolkien",
            Gender = Gender.Male
        };

        // Act

        // Assert
        author.Id.Should().Be(0);
        author.Name.Should().Be("J.R.R. Tolkien");
        author.Nationality.Should().Be(null);
    } 
}