using FileSystem.Core.Common;
using FileSystem.Core.FileSystem.Models;
using FileSystem.Core.Interfaces;

namespace FileSystem.Core.FileSystem.Interfaces;
public interface IFileServerRepository
{
    Task<IEnumerable<Folder>> GetAllAsync();
    Task<Folder> GetFolderByIdAsync(int folderId);
    Task<Folder> GetFolderWithDeletedChildredByIdAsync(int folderId);
    Task<int> AddFolderAsync(Folder folder);
    Task<int> AddFileAsync(FileModel file);
    Task<PaginationResponse<FileModel>> GetFilesPaginatedAsync(PaginationRequest request);
    Task UpdateFolderAsync(Folder folder);
    Task UpdateFileAsync(FileModel item);
    Task<FileModel> GetFileByIdAsync(int fileId);
    Task RemoveFolderWithChildrenAsync(int folderId);


}
