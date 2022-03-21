using Ardalis.GuardClauses;
using FileSystem.Core.Common;
using FileSystem.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FileSystem.EF.DbModels;

public partial class FolderDbModel : ChildFolder, IParentFolder<FolderDbModel>
{
    public HierarchyId Node { get; set; } = null!;

    public short Level { get; set; }
    public int? ParentId { get; set; }
    public FolderDbModel? Parent { get; set; }
    public ICollection<FolderDbModel> Subfolders { get; set; }
    public ICollection<FileDbModel> Files { get; set; }
    public bool IsDeleted { get; set; } = false;

    ICollection<FolderDbModel> IParentFolder<FolderDbModel>.Subfolders => throw new NotImplementedException();

    public FolderDbModel()
    {
        Subfolders = new List<FolderDbModel>();
        Files = new List<FileDbModel>();
    }
    public FolderDbModel(string folderName, HierarchyId node)
        :this()
    {
        Name = Guard.Against.NullOrWhiteSpace(folderName, nameof(folderName));
        Node = node;
    }
    public override string ToString() => $"ID: {Id} Path: {Node}";

    public override FolderDbModel AddSubfolder(string folderName)
    {
        HierarchyId newNode = GetNewChildNode();
        var newFolder = new FolderDbModel(folderName, newNode);
        
        Subfolders.Add(newFolder);
        return newFolder;
    }

    public override void Delete()
    {
        IsDeleted = true;
        DeleteFiles();
        DeleteSubFolders();
    }

    private void DeleteFiles()
    {
        foreach (FileDbModel file in Files)
        {
            file.Delete();
        }
    }

    private void DeleteSubFolders()
    {
        foreach (FolderDbModel folder in Subfolders)
        { 
            folder.Delete();
        }
    }

    public override FileDbModel CreateFile(string fileName)
    {
        FileDbModel newFile = new(fileName, this);
        Files.Add(newFile);
        return newFile;
    }

    public override void DeleteFile(IFile file)
    {
        FileDbModel fileToDelete = Files.FirstOrDefault(f => f.Equals(file));
        fileToDelete?.Delete();
    }

    private HierarchyId GetNewChildNode() => Node.GetDescendant(GetMaxChildNode(), null);

    private HierarchyId? GetMaxChildNode() => Subfolders.Max(sf => sf.Node);


}
