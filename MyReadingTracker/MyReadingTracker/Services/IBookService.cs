using MyReadingTracker.Models;
using MyReadingTracker.Resources;
using MyReadingTracker.Resources.Requests;
using MyReadingTracker.Resources.Requests.Books;
using MyReadingTracker.Resources.Responses;
using MyReadingTracker.Resources.Responses.Book;
using MyReadingTracker.Resources.Responses.Resources;

namespace MyReadingTracker.Services;

public interface IBookService
{
    PaginatedList<BookAuthorResource> GetAll(GetBooksRequest request);
    Book? GetById(int id);
    string? GetCoverImageFileName(int id);
    SaveBookResponse Create(CreateBookRequest newBook);
    void Update(Book updatedBook);
    void DeleteById(int id);
}