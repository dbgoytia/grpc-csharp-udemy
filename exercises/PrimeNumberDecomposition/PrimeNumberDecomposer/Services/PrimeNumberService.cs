using Grpc.Core;
using GRPCPrimeNumberDecomposer;

namespace GRPCPrimeNumberDecomposer.Services;

public class PrimeNumberServiceImpl : PrimeNumberService.PrimeNumberServiceBase
{
    private readonly ILogger<PrimeNumberServiceImpl> _logger;
    public PrimeNumberServiceImpl(ILogger<PrimeNumberServiceImpl> logger)
    {
        _logger = logger;
    }

    public override async Task PrimeNumberDecomposition(
        PrimeNumberDecompositionRequest request,
        IServerStreamWriter<PrimeNumberDecompositionResponse> responseStream,
        ServerCallContext context )
    {
        Console.WriteLine("The server received the request:");
        Console.WriteLine(request.ToString());

        int k = 2;
        int N = request.Number;

        while (N > 1)
        {
            if (N % k == 0)
            {
                N /= k;
                await responseStream.WriteAsync(new PrimeNumberDecompositionResponse
                {
                    PrimeFactor = k
                });

            } else
            {
                k += 1;
            }
        }

    
    }
}
