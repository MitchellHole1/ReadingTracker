using MyReadingTracker.Models;
using MyReadingTracker.Resources.Requests.Books;
using MyReadingTracker.Resources.Responses.Series;

namespace MyReadingTracker.Services;

public interface ISeriesService
{
    IEnumerable<Series> GetAll();
    Series? GetById(int id);
    SaveSeriesResponse Save(CreateSeriesRequest request);
}