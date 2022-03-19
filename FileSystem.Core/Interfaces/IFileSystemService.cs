namespace FileSystem.Core.Interfaces;

public interface IFileSystemService
{
    IEnumerable<IFolder> GetAll();
    void Add(string name, int parentId);
    void AddToRoot(string name);
    void RemoveById(int folderId);
    IFile CreateFile(string name, int parentFolderId);
    void DeleteFile(int fileId);
    IEnumerable<IFile> FilesLookup(string searchString, int page, int pageSize);
   
}
