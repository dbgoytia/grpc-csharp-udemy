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

    public override Task<GreetingReply> SayHello(GreetingRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GreetingReply
        {
            Message = String.Format("Hello {0} {1}", request.Greeting.FirstName, request.Greeting.LastName)
        });
    }
}

