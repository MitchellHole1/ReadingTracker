namespace MyReadingTracker.Infrastructure.CloudStorage;

public interface ICloudStorage
{
    public Task<Stream> GetFile(string filename);
    public void CreateFile();
}