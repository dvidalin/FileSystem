using FileSystem.Core.Common;
using FileSystem.Core.Interfaces;

namespace FileSystem.Core.FileSystem.Interfaces;
public interface IFileServerRepository
{
    Task<IEnumerable<IFolder>> GetAllAsync();
    Task<IFolder> GetFolderByIdAsync(int folderId);
    Task<IFolder> GetFolderWithDeletedChildredByIdAsync(int folderId);
    Task<int> AddFolderAsync(IFolder folder);
    Task<int> AddFileAsync(IFile file);
    Task<PaginationResponse<IFile>> GetFilesPaginatedAsync(PaginationRequest request);
    Task UpdateFolderAsync(IFolder folder);
    Task UpdateFileAsync(IFile item);
    Task<IFile> GetFileByIdAsync(int fileId);
    Task RemoveFolderWithChildrenAsync(int folderId);


}
