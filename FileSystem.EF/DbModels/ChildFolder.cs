using FileSystem.Core.Interfaces;

namespace FileSystem.EF.DbModels;
public abstract class ChildFolder : IBaseEntity<int>, IFolder
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public abstract IFolder AddSubfolder(string name);
    public abstract IFile CreateFile(string fileName);
    public abstract void Delete();
    public abstract void DeleteFile(IFile file);
}
