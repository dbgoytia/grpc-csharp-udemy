using System.Threading.Tasks;
using Grpc.Net.Client;
using Grpc.Core;
using GRPCPrimeNumberDecomposerClient;


using var channel = GrpcChannel.ForAddress("http://localhost:5211");
await channel.ConnectAsync().ContinueWith((task) =>
{
    if (task.Status == TaskStatus.RanToCompletion)
        Console.WriteLine("Client connected successfully");
});

var client = new PrimeNumberService.PrimeNumberServiceClient(channel);

DoPrimeNumberDecomposition(client);

Console.ReadKey();

async static void DoPrimeNumberDecomposition(PrimeNumberService.PrimeNumberServiceClient client)
{
    var reply = client.PrimeNumberDecomposition(
        new PrimeNumberDecompositionRequest
        {
            Number = 10052
        });
   
    while (await reply.ResponseStream.MoveNext())
    {
        Console.WriteLine("Reply: " + reply.ResponseStream.Current.PrimeFactor);
        await Task.Delay(200);
    }
}