using FileSystem.Core.Common;
using FileSystem.Core.Interfaces;

namespace FileSystem.EF.DbModels;

public partial class FileDbModel : BaseEntity<int>, IFile, ISoftDeleteEntity, IChangeHistoryEntity
{
    public int ParentFolderId { get; set; }
    public FolderDbModel ParentFolder { get; set; } = null!;
    public bool IsDeleted { get; set; } = false;
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime DateModified { get; set; } = DateTime.Now;

    public FileDbModel()
    {

    }

    private FileDbModel(string name)
    { 
        Name = name;
    }

    public FileDbModel(string name, FolderDbModel parentFolder)
        :this(name)
    {
        ParentFolder = parentFolder;
    }

    public FileDbModel(string name, int parentFolderId)
        :this(name)
    {
        ParentFolderId = parentFolderId;
    }

    public override string ToString() => $"{Name}";

    public void Delete() => IsDeleted = true;
}
