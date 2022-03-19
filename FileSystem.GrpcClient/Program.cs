using FileSystem.GrpcServer;
using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress("http://localhost:5098");

var client = new FileServer.FileServerClient(channel);

var reply = await client.GetAllAsync(new Empty());

//await client.AddFolderAsync(new AddRequest { Name = "Folder iz klijenta", ParentFolderId = 1 });

//await client.RemoveFolderByIdAsync(new IdRequest { Id = 2 });

//for (var i = 0; i < 20; i++)
//{
//    await client.AddFileAsync(new AddRequest { Name = $"File iz klijenta {i}", ParentFolderId = 3 });

//}

var lookup = await client.FileLookupAsync(new LookupRequest { Page = 1, SearchString = "Fil", Size = 10 });

Console.WriteLine("Done!!!");
Console.ReadLine();
