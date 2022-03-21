using FileSystem.Core.Interfaces;

namespace FileSystem.EF.DbModels;
public abstract class ChildFolder : IBaseEntity<int>, IFolder
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public IParentFolder<IFolder> AddSubfolder(string name) => throw new NotImplementedException();
    public abstract IFile CreateFile(string fileName);
    public abstract void Delete();
    public abstract void DeleteFile(IFile file);
}
