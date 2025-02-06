using MyReadingTracker.Models;
using MyReadingTracker.Resources.Requests.Books;
using MyReadingTracker.Resources.Responses.ReadingSession;

namespace MyReadingTracker.Services;

public interface IReadingSessionService
{
    IEnumerable<ReadingSession> GetAll();

    IEnumerable<ReadingSession> GetCurrentReadings();
    ReadingSession? GetById(int id);
    SaveReadingSessionResponse Create(ReadingSession newReadingSession);
    SaveReadingSessionResponse Update(int id, UpdateReadingSessionRequest updatedReadingSession);
}