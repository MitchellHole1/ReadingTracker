using MyReadingTracker.Models;

namespace MyReadingTracker.Services;

public interface IGenreService
{
    IEnumerable<Genre> GetAll();
}