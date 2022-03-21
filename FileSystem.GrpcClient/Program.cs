using FileSystem.GrpcServer;
using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress("http://localhost:5098");

var client = new FileServer.FileServerClient(channel);

//GetAllReply reply = await client.GetAllAsync(new Empty());

//foreach (var folder in reply.Folders)
//{
var t = await client.FileLookupAsync(new LookupRequest { SearchString = "Moj", Page = 1, Size = 10 });
//}

//await client.AddFolderAsync(new AddRequest { Name = "Folder iz klijenta", ParentFolderId = 1 });


//for (var i = 0; i < 20; i++)
//{
//    await client.AddFileAsync(new AddRequest { Name = $"File iz klijenta {i}", ParentFolderId = 3 });

//}


Console.WriteLine("Done!!!");
Console.ReadLine();
