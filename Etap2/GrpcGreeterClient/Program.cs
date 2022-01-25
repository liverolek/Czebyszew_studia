// See https://aka.ms/new-console-template for more information

using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;

using System;

namespace ConsoleApp3
{
    class Program
    {
        static async Task Main(string[] args)
        {   
            Console.WriteLine("Hello, World!");
            GrpcChannel[] channles = new GrpcChannel[args.Length];
            for(int i =0; i<args.Length; i++){
                Console.WriteLine(args[i]);
                channles[i] = GrpcChannel.ForAddress("http://localhost:"+args[i]);
                var client = new Greeter.GreeterClient(channles[i]);
                var reply = await client.SayHelloAsync(
                            new HelloRequest { Name = "GreeterClient"+args[i] });
                Console.WriteLine("Greeting: " + reply.Message);
            }
            
            
            
            // The port number must match the port of the gRPC server.
            // var channel = GrpcChannel.ForAddress("http://localhost:9874");
            // var client = new Greeter.GreeterClient(channel);
            // var reply = await client.SayHelloAsync(
            //                 new HelloRequest { Name = "GreeterClient" });
            // Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
