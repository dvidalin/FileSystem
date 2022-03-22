using FileSystem.Core.FileSystem.Models;

namespace FileSystem.Core.Interfaces;
public interface IParentFolder : IFolder
{
    FileModel CreateFile(string fileName);
    void DeleteFile(FileModel file);
    Folder AddSubfolder(string name);

}
