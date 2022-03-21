namespace FileSystem.Core.Interfaces;

public interface IFolder : IBaseEntity<int>
{
    void Delete();
    IFile CreateFile(string fileName);
    void DeleteFile(IFile file);
    IParentFolder<IFolder> AddSubfolder(string name);

}
