using MyReadingTracker.Models;
using MyReadingTracker.Resources;
using MyReadingTracker.Resources.Requests.Books;
using MyReadingTracker.Resources.Responses.Author;
using MyReadingTracker.Resources.Responses.Resources;

namespace MyReadingTracker.Services;

public interface IAuthorService
{
    PaginatedList<Author> GetAll(GetAuthorRequest request);
    Author? GetById(int id);
    IEnumerable<Book> GetBooksByAuthorId(int authorId);
    SaveAuthorResponse Create(Author newAuthor);
}