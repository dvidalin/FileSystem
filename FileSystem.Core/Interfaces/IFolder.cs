namespace FileSystem.Core.Interfaces;

public interface IFolder : IBaseEntity<int>
{
    short Level { get; set; }
    int? ParentId { get; set; }
    IFolder AddSubfolder(string name);
    void Delete();
    void  DeleteSubFolderById(int subfolderId);
    IFile CreateFile(string fileName);
    void DeleteFile(IFile file);
    void DeleteFileById(int fileId);
}
