using MyReadingTracker.Models;
using MyReadingTracker.Resources.Requests.Books;
using MyReadingTracker.Resources.Responses;
using MyReadingTracker.Resources.Responses.Book;

namespace MyReadingTracker.Services;

public interface IBookService
{
    IEnumerable<Book> GetAll();
    Book? GetById(int id);
    SaveBookResponse Create(CreateBookRequest newBook);
    void Update(Book updatedBook);
    void DeleteById(int id);
}