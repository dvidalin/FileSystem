using FileSystem.Core.Common;
using FileSystem.Core.Interfaces;

namespace FileSystem.GrpcServer.ModelExtensions;

public static class FileSystemServiceExtensions
{
    public static FolderReply GetFolderReply(this IFolder folder)
        => new()
        { 
            Id = folder.Id,
            Name = folder.Name
        };

    public static FileReply GetFileReply(this IFile file)
        => new()
        {
            Id = file.Id,
            Name = file.Name
        };

    public static PaginationRequest GetPaginationRequest(this LookupRequest request)
        => new() {
            SearchString = request.SearchString,
            PageNumber = request.Page,
            PageSize = request.Size
        };

    public static LookupReply GetResponse(this PaginationResponse<IFile> response)
    {
        LookupReply lookupReply = new() { 
            PageNumber = response.PageNumber,
            PageSize = response.PageSize,
            TotalCount = response.TotalCount,
            FilteredCount = response.FilteredCount
        };
        lookupReply.Files.AddRange(response.Items.Select(i => i.GetFileReply()));

        return lookupReply;
    }

}
