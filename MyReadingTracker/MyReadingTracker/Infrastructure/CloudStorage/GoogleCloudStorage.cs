using Google.Api.Gax;
using Google.Cloud.Storage.V1;

namespace MyReadingTracker.Infrastructure.CloudStorage;

public class GoogleCloudStorage : ICloudStorage
{

    private readonly ILogger<GoogleCloudStorage> _logger;
    private StorageClient _storageClient;

    private const string BucketName = "book-cover-images";

    public GoogleCloudStorage(ILogger<GoogleCloudStorage> logger, bool isLocal = true)
    {
        _logger = logger;
        var builder = new StorageClientBuilder()
        {
            EmulatorDetection = isLocal ? EmulatorDetection.EmulatorOnly : EmulatorDetection.ProductionOnly
        };
        _storageClient = builder.Build();
    }
        
    public async Task<Stream> GetFile(string fileName)
    {
        var stream = new MemoryStream();
        var obj = await _storageClient.DownloadObjectAsync(BucketName, fileName, stream);
        stream.Position = 0;
        return stream;
    }

    public void CreateFile()
    {
    }
}