using FileSystem.GrpcServer;
using Grpc.Net.Client;

//var channel = GrpcChannel.ForAddress("http://localhost:5098"); //iis
var channel = GrpcChannel.ForAddress("http://localhost:5001"); //docker

var client = new FileServer.FileServerClient(channel);

//GetAllReply reply = await client.GetAllAsync(new Empty());

//foreach (var folder in reply.Folders)
//{
//var t = await client.FileLookupAsync(new LookupRequest { SearchString = "Moj", Page = 1, Size = 10 });
//}




for (int i = 1; i <= 5; i++)
{
    await client.AddFolderAsync(new AddRequest { Name = "Novi Folder", ParentFolderId = 1 });
    await client.AddFileAsync(new AddRequest { Name = "Novi File", ParentFolderId = 1 });
}


Console.WriteLine("Done!!!");
Console.ReadLine();
