using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;

using var channel = GrpcChannel.ForAddress("http://localhost:5252");

await channel.ConnectAsync().ContinueWith((task) =>
{
    if (task.Status == TaskStatus.RanToCompletion)
        Console.WriteLine("Client connected successfully");
});


var client = new Greeter.GreeterClient(channel);

DoSimpleGreet(client, "Diego", "Canizales");

Console.WriteLine("Press any key to exit...");
Console.ReadKey();


async static void DoSimpleGreet(Greeter.GreeterClient client, String firstName, String lastName )
{
    var greeting = new Greeting
    {
        FirstName = firstName,
        LastName = lastName
    };
    var reply = await client.SayHelloAsync(
    new GreetingRequest
    {
        Greeting = greeting
    });
    Console.WriteLine("Greeting: " + reply.Message);
}
