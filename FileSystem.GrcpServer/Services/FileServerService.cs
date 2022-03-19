using FileSystem.Core.Interfaces;
using FileSystem.GrpcServer.ModelExtensions;
using Grpc.Core;

namespace FileSystem.GrpcServer.Services
{
    public class FileServerService : FileServer.FileServerBase
    {
        private readonly ILogger<FileServerService> _logger;
        private readonly IFileSystemService _fileSystemService;

        public FileServerService(ILogger<FileServerService> logger, IFileSystemService fileSystemService)
        {
            _logger = logger;
            _fileSystemService = fileSystemService;
        }

        public override Task<GetAllReply> GetAll(Empty request, ServerCallContext context)
        {
            var folders = _fileSystemService.GetAll();

            GetAllReply reply = new GetAllReply();
            reply.Folders.AddRange(folders.Select(x => x.GetFolderReply()));

            return Task.FromResult(reply);
        }

        public override Task<Empty> AddFolder(AddRequest request, ServerCallContext context)
        {
            _fileSystemService.Add(request.Name, request.ParentFolderId);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> RemoveFolderById(IdRequest request, ServerCallContext context)
        {
            _fileSystemService.RemoveById(request.Id);
            return Task.FromResult(new Empty());
        }

        public override Task<FileReply> AddFile(AddRequest request, ServerCallContext context)
        {
            var newFile = _fileSystemService.CreateFile(request.Name, request.ParentFolderId);

            var reply = newFile.GetFileReply();

            return Task.FromResult(reply);
        }

        public override Task<LookupReply> FileLookup(LookupRequest request, ServerCallContext context)
        {
            var lookupResult = _fileSystemService.FilesLookup(request.SearchString, request.Page, request.Size);
            var reply = new LookupReply();
            reply.Files.AddRange(lookupResult.Select(x => x.GetFileReply()));
            return Task.FromResult(reply);
        }
    }
}
