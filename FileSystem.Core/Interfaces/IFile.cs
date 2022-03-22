namespace FileSystem.Core.Interfaces;

public interface IFile : IBaseEntity<int>
{
    void Delete();
}
