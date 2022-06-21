using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcGreeterClient;

using var channel = GrpcChannel.ForAddress("http://localhost:5015");

await channel.ConnectAsync().ContinueWith((task) =>
{
    if (task.Status == TaskStatus.RanToCompletion)
        Console.WriteLine("Client connected successfully");
});

var client = new Greeter.GreeterClient(channel);

DoSimpleGreet(client, "Diego", "Canizales");
DoGreetManyTimes(client, "Diego", "Canizales");

Console.WriteLine("Press any key to exit...");
channel.ShutdownAsync().Wait();
Console.ReadKey();

async static void DoSimpleGreet(Greeter.GreeterClient client, String firstName, String lastName)
{
    var greeting = new Greeting
    {
        FirstName = firstName,
        LastName = lastName
    };
    var reply = await client.GreetAsync(
    new GreetingRequest
    {
        Greeting = greeting
    });
    Console.WriteLine("Greeting: " + reply.Message);
}

async static void DoGreetManyTimes(Greeter.GreeterClient client, String firstName, String lastName)
{
    var greeting = new Greeting
    {
        FirstName = firstName,
        LastName = lastName
    };
    var reply = client.GreetManyTimes(
    new GreetingManyTimesRequest
    {
        Greeting = greeting
    });
    while (await reply.ResponseStream.MoveNext())
    {
        Console.WriteLine("GreetingManyTimes : " + reply.ResponseStream.Current.Message);
        await Task.Delay(200);
    }
}