using FileSystem.Core.Common;
using FileSystem.Core.Interfaces;

namespace FileSystem.Core.FileSystem.Interfaces;
public interface IFileServerRepository<TFolder, TFile>
    where TFolder : IFolder
    where TFile : IFile
{
    Task<IEnumerable<TFolder>> GetAllAsync();
    Task<TFolder> GetFolderByIdAsync(int folderId);
    Task<TFolder> GetFolderWithDeletedChildredByIdAsync(int folderId);
    Task AddFolderAsync(TFolder folder);
    Task<TFile> AddFileAsync(TFile file);
    Task<PaginationResponse<TFile>> GetFilesPaginatedAsync(PaginationRequest request);
    Task UpdateFolderAsync(TFolder folder);
    Task UpdateFileAsync(TFile item);
    Task<TFile> GetFileByIdAsync(int fileId);


}
