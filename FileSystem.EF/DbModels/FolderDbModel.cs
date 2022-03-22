using Ardalis.GuardClauses;
using FileSystem.Core.Common;
using FileSystem.Core.Exceptions;
using FileSystem.Core.FileSystem.Models;
using FileSystem.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FileSystem.EF.DbModels;

public partial class FolderDbModel : Folder, IParentFolder, IFolder
{
    public HierarchyId Node { get; set; } = null!;

    public short Level { get; set; }
    public int? ParentId { get; set; }
    public FolderDbModel? Parent { get; set; }
    public new ICollection<FolderDbModel> Subfolders { get; set; } = new List<FolderDbModel>();
    public new ICollection<FileDbModel> Files { get; set; } = new List<FileDbModel>();
    public bool IsDeleted { get; set; } = false;

    public FolderDbModel(string name): base(name)
    {

    }

    public FolderDbModel(string folderName, HierarchyId node)
        :base(folderName)
    {
        Node = node;
    }

    public override string ToString() => $"ID: {Id} Path: {Node}";

    public override FolderDbModel AddSubfolder(string folderName)
    {

        HierarchyId newNode = GetNewChildNode();
        string name = GetAvailableSubfolderName(folderName);
        FolderDbModel newFolder = new (name, newNode);
        
        Subfolders.Add(newFolder);
        return newFolder;
    }

    public override void Delete()
    {
        IsDeleted = true;
        DeleteFiles();
        DeleteSubfolders(); 
    }

    protected override void DeleteFiles()
    {
        foreach (var file in Files)
        {
            file.Delete();
        }
    }

    protected override void DeleteSubfolders()
    {
        foreach (var folder in Subfolders)
        {
            folder.Delete();
        }
    }

    public override FileDbModel CreateFile(string fileName)
    {
        string newName = GetAvailableFileName(fileName);

        FileDbModel newFile = new(newName, this);
        Files.Add(newFile);
        return newFile;
    }

    public HierarchyId GetNewChildNode() => Node.GetDescendant(GetMaxChildNode(), null);

    private HierarchyId? GetMaxChildNode() => Subfolders.Max(sf => sf.Node);

    protected override string GetAvailableSubfolderName(string desiredName)
    {
        List<string> usedNames = Subfolders
                                    .Select(sf => sf.Name)
                                    .ToList();

        return NameChecker.GetAvailableName(desiredName, usedNames);
    }

    protected override string GetAvailableFileName(string desiredName)
    {
        List<string> usedNames = Files
                                    .Select(f => f.Name)
                                    .ToList();

        return NameChecker.GetAvailableName(desiredName, usedNames);
    }

    public override bool IsRoot() => Node == HierarchyId.GetRoot();
}
