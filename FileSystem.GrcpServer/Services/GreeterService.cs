using FileSystem.Core.Interfaces;
using Grpc.Core;

namespace FileSystem.GrpcServer.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    private readonly IFileSystemService _folderRepository;
    public GreeterService(ILogger<GreeterService> logger, IFileSystemService folderRepository)
    {
        _logger = logger;
        _folderRepository = folderRepository;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        //_folderRepository.Add("Nested Nested Folder", 16);

        //_folderRepository.Add("Novi root subfolder!", 1);
        //_folderRepository.GetAll();
        //_folderRepository.CreateFile("Moj novi file", 1);

        var folders = _folderRepository.GetAll();

        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        }); ;
    }
}
