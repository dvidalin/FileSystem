using FileSystem.Core.Common;
using FileSystem.Core.FileSystem.Models;
using FileSystem.Core.Interfaces;

namespace FileSystem.EF.DbModels;

public partial class FileDbModel : FileModel, IFile
{
    public int ParentFolderId { get; set; }
    public FolderDbModel ParentFolder { get; set; } = null!;
    public bool IsDeleted { get; set; } = false;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime DateModified { get; set; } 

    private FileDbModel(string name) : base(name)
    { 
    }

    public FileDbModel(string name, FolderDbModel parentFolder)
        :this(name)
    {
        ParentFolder = parentFolder;
    }
    public override string ToString() => $"{Name}";

    public override void Delete()
    { 
        IsDeleted = true;
        DateModified = DateTime.UtcNow;
    }
}
