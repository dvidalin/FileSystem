using FileSystem.Core.Exceptions;
using FileSystem.Core.Interfaces;
using FileSystem.EF.DbModels;
using FileSystem.EF.QueryStore;

namespace FileSystem.EF;

public class FileSystemService : IFileSystemService
{
    private readonly FileSystemDbContext _dbContext;

    public FileSystemService(FileSystemDbContext systemContext)
    {
        _dbContext = systemContext;
        
    }

    public void Add(string name, int parentId)
    {
        FolderDbModel parentFolder = GetById(parentId);

        Add(new FolderDbModel(name, parentFolder));

    }

    public void AddToRoot(string name)
    {
        FolderDbModel rootFolder = _dbContext
            .FoldersQuery()
            .IncludeDeleted()
            .IsRootNode()
            .WithChildren()
            .First();

        Add(new FolderDbModel(name, rootFolder));
    }

    IEnumerable<IFolder> IFileSystemService.GetAll()
        => _dbContext
            .FoldersQuery()
            .WithAllRelations();        

    private void Add(FolderDbModel folderDbModel)
    { 
        _dbContext.Add(folderDbModel);
        _dbContext.SaveChanges();
    }

    public void RemoveById(int folderId)
    {
        FolderDbModel originalFolderToRemove = GetById(folderId);

        IQueryable<FolderDbModel> foldersToRemove = _dbContext
                                                    .FoldersQuery()
                                                    .IsDescendantOf(originalFolderToRemove);

        //No need to remove original explicity, since node is considered it's own descendant
        foreach (var folder in foldersToRemove) {
            folder.Delete();
        }

        _dbContext.SaveChanges();
    }

    private FolderDbModel GetById(int folderId)
    {
        try
        {
            return _dbContext
                    .FoldersQuery()
                    .ById(folderId)
                    .WithAllRelations()
                    .First();
                    
                    
        }
        catch (InvalidOperationException)
        {
            throw new ItemNotFoundException(folderId);
        }

    }

    public IFile CreateFile(string name, int parentFolderId)
    {
        FolderDbModel parentFolder = GetById(parentFolderId);
        IFile newFile = parentFolder.CreateFile(name);

        _dbContext.SaveChanges();

        return newFile;
    }

    public void DeleteFile(int fileId)
    {
        FileDbModel fileToRemove =_dbContext
                            .Files
                            .ById(fileId)
                            .First();

        fileToRemove.Delete();

        _dbContext.SaveChanges();
    }

    public IEnumerable<IFile> FilesLookup(string searchString, int page, int pageSize) 
        => _dbContext
            .FilesQuery()
            .NameStartsWith(searchString)
            .Paginate(page, pageSize);
}


