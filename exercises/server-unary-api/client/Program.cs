using System;
using Grpc.Core;
using Calculator;

namespace client
{
    class Program
    {
        const string Target = "127.0.0.1:50051";

        static void Main(string[] args)
        {
            Channel channel = new Channel(Target, ChannelCredentials.Insecure);

            channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("Client connected successfully");
            });

            var client = new CalculatorService.CalculatorServiceClient(channel);

            // Sample requests
            DoSumRequest(client);
            DoSubstractRequest(client);


            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }

        public static void DoSubstractRequest(CalculatorService.CalculatorServiceClient client)
        {
            var request = new SubstractRequest()
            {
                A = 1,
                B = 2
            };

            var response = client.Substract(request);

            Console.WriteLine("Substract: " + response.Result);
        }

        public static void DoSumRequest(CalculatorService.CalculatorServiceClient client)
        {
            var request = new SumRequest()
            {
                A = 1,
                B = 2
            };

            var response = client.Sum(request);

            Console.WriteLine("Sum: " + response.Result);
        }
    }
}