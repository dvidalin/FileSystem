namespace FileSystem.Core.Interfaces;

public interface IFolder : IBaseEntity<int>
{
    void Delete();
    IFile CreateFile(string fileName);
    void DeleteFile(IFile file);
    IFolder AddSubfolder(string name);

}
