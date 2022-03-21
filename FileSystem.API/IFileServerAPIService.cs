using FileSystem.Core.Common;
using FileSystem.Core.Interfaces;

namespace FileSystem.API;

public interface IFileServerAPIService
{
    Task<int> AddFolderAsync(string folderName, int parentFolderId);
    Task RemoveFolderByIdAsync(int id);
    Task<int> AddFileAsync(string fileName, int parentFolderId);
    Task RemoveFileByIdAsync(int fileId);
    Task<PaginationResponse<IFile>> FileLookupAsync(PaginationRequest request);

}
