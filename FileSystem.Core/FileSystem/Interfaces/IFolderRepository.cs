using FileSystem.Core.Interfaces;

namespace FileSystem.Core.FileSystem.Interfaces;
public interface IFolderRepository<TFolder> where TFolder : IFolder
{
    Task<TFolder> GetByIdAsync(int folderId);
    Task CreateAsync(TFolder folder);
    Task DeleteAsync(TFolder folderToDelete);
}
