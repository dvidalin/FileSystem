using FileSystem.Core.FileSystem.Models;

namespace FileSystem.Core.Interfaces;
public interface IParentFolder : IFolder
{
    ICollection<Folder> GetSubfolders();
    ICollection<FileModel> GetFiles();
    FileModel CreateFile(string fileName);
    void DeleteFile(FileModel file);
    Folder AddSubfolder(string name);

}
