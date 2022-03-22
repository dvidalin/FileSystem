using Ardalis.GuardClauses;
using FileSystem.Core.Common;
using FileSystem.Core.Interfaces;

namespace FileSystem.Core.FileSystem.Models;
public class Folder : BaseEntity<int>, IParentFolder, IFolder
{
    public ICollection<Folder> Subfolders { get; set; } = new List<Folder>();
    public ICollection<FileModel> Files { get; set; } = new List<FileModel>();

    public Folder(string folderName) : base(folderName)
    {        
        Name = Guard.Against.InvalidCharacter(folderName, nameof(folderName));
    }

    public virtual Folder AddSubfolder(string name)
    { 
        string nameToAdd = GetAvailableSubfolderName(name);

        Folder newFolder = new(nameToAdd);
        Subfolders.Add(newFolder);  

        return newFolder;
    }


    public virtual FileModel CreateFile(string fileName)
    {
        string nameToAdd = GetAvailableFileName(fileName);

        FileModel newFile = new(nameToAdd);
        Files.Add(newFile);
        
        return newFile;
    }

    public virtual void Delete()
    {
        Guard.Against.DeleteRootFolder(this);
        DeleteFiles();
        DeleteSubfolders();
    }

    public virtual void DeleteFile(FileModel file)
    {
        Files.Remove(file);
        file.Delete();
    }

    protected virtual void DeleteSubfolders()
    {
        foreach (Folder folder in Subfolders)
        {
            Subfolders.Remove(folder);
            folder.Delete();
        }
    }

    protected virtual void DeleteFiles()
    {
        foreach (FileModel file in Files)
        {
            Files.Remove(file);
            file.Delete();
        }
    }

    protected virtual string GetAvailableSubfolderName(string desiredName)
    {
        List<string> usedNames = Subfolders
                                    .Select(sf => sf.Name)
                                    .ToList();

        return NameChecker.GetAvailableName(desiredName, usedNames);
    }

    protected virtual string GetAvailableFileName(string desiredName)
    {
        List<string> usedNames = Files
                                    .Select(f => f.Name)
                                    .ToList();

        return NameChecker.GetAvailableName(desiredName, usedNames);
    }

    public virtual bool IsRoot() => false;
}
