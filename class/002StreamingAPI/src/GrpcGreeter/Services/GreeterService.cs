using Grpc.Core;
using GrpcGreeter;

namespace GrpcGreeter.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<GreetingResponse> Greet(GreetingRequest request, ServerCallContext context)
    {
        Console.WriteLine("The server received the Greet request : ");
        Console.WriteLine(request.ToString());
        return Task.FromResult(new GreetingResponse
        {
            Message = String.Format("Hello {0} {1}", request.Greeting.FirstName, request.Greeting.LastName)
        });
    }

    public override async Task GreetManyTimes(GreetingManyTimesRequest request, IServerStreamWriter<GreetingManyTimesResponse> responseStream, ServerCallContext context)
    {
        Console.WriteLine("The server received the GreetManyTimes request : ");
        Console.WriteLine(request.ToString());
        foreach (int _ in Enumerable.Range(1, 10))
        {
            await responseStream.WriteAsync(new GreetingManyTimesResponse
            {
                Message = String.Format("Hello {0} {1}", request.Greeting.FirstName, request.Greeting.LastName)
            });
        };
    }
}

