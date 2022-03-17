using FileSystem.GrpcServer;
using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress("http://localhost:5098");

var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(new HelloRequest { Name = "Denis" });


Console.WriteLine(reply.Message);
Console.ReadLine();
