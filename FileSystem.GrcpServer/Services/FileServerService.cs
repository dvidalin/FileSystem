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

    public override async Task<IdMessage> AddFolder(AddRequest request, ServerCallContext context)
    {
        try
        {
            int newFolderId = await _fileServerService.AddFolderAsync(request.Name, request.ParentFolderId);

            return new() { Id = newFolderId };
        }
        catch (Exception ex) {
            var t = 5;
        }

        throw new NotImplementedException();
    }

    public override async Task<Empty> RemoveFolderById(IdMessage request, ServerCallContext context)
    {
        await _fileServerService.RemoveFolderByIdAsync(request.Id);

        return new ();
    }

    public override async Task<IdMessage> AddFile(AddRequest request, ServerCallContext context)
    {
        int newFileId = await _fileServerService.AddFileAsync(request.Name, request.ParentFolderId);

        return new (){ Id = newFileId };

        
    }

    public override async Task<LookupReply> FileLookup(LookupRequest request, ServerCallContext context)
    {
        PaginationResponse<IFile> paginationResponse = await _fileServerService.FileLookupAsync(request.GetPaginationRequest());

        return paginationResponse.GetResponse();
    }
}
