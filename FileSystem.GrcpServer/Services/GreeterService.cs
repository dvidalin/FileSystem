using FileSystem.Core.Interfaces;
using Grpc.Core;

namespace FileSystem.GrpcServer.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IFolderRepository _folderRepository;
        public GreeterService(ILogger<GreeterService> logger, IFolderRepository folderRepository)
        {
            _logger = logger;
            _folderRepository = folderRepository;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _folderRepository.Add("Moj Moj folde33354353r", 3);

            //var folders = _folderRepository.GetAll();

            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            }); ;
        }
    }
}