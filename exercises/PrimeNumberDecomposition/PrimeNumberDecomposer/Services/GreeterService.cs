using Grpc.Core;
using GRPCPrimeNumberDecomposer;

namespace GRPCPrimeNumberDecomposer.Services;

public class PrimeNumberDecomposerService : PrimeNumberDecomposer.PrimeNumberDecomposerBase
{
    private readonly ILogger<PrimeNumberDecomposerService> _logger;
    public PrimeNumberDecomposerService(ILogger<PrimeNumberDecomposerService> logger)
    {
        _logger = logger;
    }

    public override async Task PrimeNumberDecompose(
        PrimeNumberDecompositionRequest request,
        IServerStreamWriter<PrimeNumberDecompositionResponse> responseStream,
        ServerCallContext context )
    {

        int k = 2;
        int N = Int32.Parse(request.Number);

        while (N > 1)
        {
            if (N % k == 0)
            {
                await responseStream.WriteAsync(new PrimeNumberDecompositionResponse
                {
                    Message = "Decomposed: " + k
                });

                N /= k;
            } else
            {
                k += 1;
            }
        }

    
    }
}
