using FileSystem.API;
using FileSystem.Core.Common;
using FileSystem.Core.Interfaces;
using FileSystem.GrpcServer.ModelExtensions;
using Grpc.Core;

namespace FileSystem.GrpcServer.Services;

public class FileServerService : FileServer.FileServerBase
{
    private readonly ILogger<FileServerService> _logger;
    private readonly IFileServerAPIService _fileServerService;

    public FileServerService(ILogger<FileServerService> logger, IFileServerAPIService fileServerService)
    {
        _logger = logger;
        _fileServerService = fileServerService;
    }

    public override Task<GetAllReply> GetAll(Empty request, ServerCallContext context)
    {

        return Task.FromResult(new GetAllReply());
    }

    public override async Task<Empty> AddFolder(AddRequest request, ServerCallContext context)
    {
        await _fileServerService.AddFolderAsync(request.Name, request.ParentFolderId);

        return new ();

    }

    public override async Task<Empty> RemoveFolderById(IdRequest request, ServerCallContext context)
    {
        await _fileServerService.RemoveFolderByIdAsync(request.Id);

        return new ();
    }

    public override async Task<FileReply> AddFile(AddRequest request, ServerCallContext context)
    {
        IFile newFile = await _fileServerService.AddFileAsync(request.Name, request.ParentFolderId);

        return newFile.GetFileReply();

        
    }

    public override async Task<LookupReply> FileLookup(LookupRequest request, ServerCallContext context)
    {
        PaginationResponse<IFile> paginationResponse = await _fileServerService.FileLookupAsync(request.GetPaginationRequest());

        return paginationResponse.GetResponse();
    }
}
