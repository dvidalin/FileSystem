using FileSystem.Core.Common;
using FileSystem.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FileSystem.EF.DbModels;

public partial class FolderDbModel : BaseEntity<int>, IFolder
{
    public HierarchyId Node { get; set; } = null!;

    public short Level { get; set; }
    public int? ParentId { get; set; }
    public FolderDbModel? Parent { get; set; }
    public ICollection<FolderDbModel> Subfolders { get; set; }
    public ICollection<FileDbModel> Files { get; set; }
    public bool IsDeleted { get; set; } = false;

    public FolderDbModel(string name)
    {
        Name = name;
        Subfolders = new List<FolderDbModel>();
        Files = new List<FileDbModel>();
    }

    public FolderDbModel(string name, int id)
        :this(name)
    {
        Id = id;
    }

    public FolderDbModel(string name, FolderDbModel parent)
        :this(name)
    {
        Parent = parent;
        Node = parent.GetNewChildNode();
    }

    public override string ToString() => $"ID: {Id} Path: {Node}";

    public IFolder AddSubfolder(string name)
    {
        var newFolder = new FolderDbModel(name);
        Subfolders.Add(newFolder);
        return newFolder;
    }

    public void Delete()
    {
        IsDeleted = true;
        foreach (var file in Files) {
            file.Delete();
        }
    }

    public void DeleteSubFolderById(int subfolderId) => GetSubFolderById(subfolderId).Delete();
    

    public IFile CreateFile(string fileName)
    {
        FileDbModel newFile = new(fileName, this);
        Files.Add(newFile);
        return newFile;
    }

    public void DeleteFile(IFile file)
    {
        FileDbModel fileToDelete = Files.FirstOrDefault(f => f.Equals(file));
        fileToDelete?.Delete();
    }

    public void DeleteFileById(int fileId)
    {
        FileDbModel fileToDelete = Files.FirstOrDefault(f => f.Id == fileId);
        fileToDelete?.Delete();
    }

    private FolderDbModel GetSubFolderById(int id) => Subfolders.Single(sf => sf.Id == id);

    private HierarchyId GetNewChildNode() => Node.GetDescendant(GetMaxChildNode(), null);

    private HierarchyId? GetMaxChildNode() => Subfolders.Max(sf => sf.Node);


}
