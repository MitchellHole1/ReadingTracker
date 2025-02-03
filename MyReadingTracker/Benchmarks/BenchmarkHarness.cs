using BenchmarkDotNet.Attributes;

namespace Benchmarks;

public class BenchmarkHarness
{
    [Params(50)]
    public int IterationCount;
    
    private readonly RestClient _restClient = new RestClient();

    [Benchmark]
    public async Task RestGetSmallPayloadAsync()
    {
        for(int i = 0; i < IterationCount; i++)
        {
            await _restClient.GetSmallPayloadAsync();
        }
    }
}