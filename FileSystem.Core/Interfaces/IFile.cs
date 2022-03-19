namespace FileSystem.Core.Interfaces;

public interface IFile : IBaseEntity<int>
{
    int ParentFolderId { get; set; }
    void Delete();
}
