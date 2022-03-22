using FileSystem.Core.Common;
using FileSystem.Core.Exceptions;
using FileSystem.Core.FileSystem.Interfaces;
using FileSystem.Core.FileSystem.Models;
using FileSystem.Core.Interfaces;
using FileSystem.EF.DbModels;
using FileSystem.EF.QueryStore;
using Microsoft.EntityFrameworkCore;

namespace FileSystem.EF;
public class FileServerRepository : IFileServerRepository
{
    private readonly FileSystemDbContext _dbContext;

    public FileServerRepository(FileSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddFileAsync(FileModel file)
    {
        _dbContext.Files.Add((FileDbModel)file);

        await _dbContext.SaveChangesAsync();

        return file.Id;
    }
    public async Task<int> AddFolderAsync(Folder folder)
    {

        _dbContext.Folders.Add((FolderDbModel)folder);

        await _dbContext.SaveChangesAsync();

        return folder.Id;
    }

    public async Task<IEnumerable<Folder>> GetAllAsync()
        => await _dbContext.Folders.ToListAsync();
    public async Task<FileModel> GetFileByIdAsync(int fileId)
        => await _dbContext
                    .FilesQuery()
                    .ById(fileId)
                    .SingleAsync();

    public async Task<PaginationResponse<FileModel>> GetFilesPaginatedAsync(PaginationRequest request)
    {
        PaginationResponse<FileModel> response = new(request);

        var query = _dbContext
                        .FilesQuery()
                        .SetSearchFilters(request.SearchString);

        response.FilteredCount = await query.CountAsync();
        response.Items = query.Paginate(request.PageNumber, request.PageSize);

        response.TotalCount = await _dbContext.Files.CountAsync();

        return response;

    }
    public async Task<Folder> GetFolderByIdAsync(int folderId)
        => await _dbContext
                    .FoldersQuery()
                    .ById(folderId)
                    .WithAllRelations()
                    .SingleAsync();
    public async Task<Folder> GetFolderWithDeletedChildredByIdAsync(int folderId)
        => await _dbContext
                    .FoldersQuery()
                    .IgnoreQueryFilters()
                    .Where(f => !f.IsDeleted)
                    .ById(folderId)
                    .WithAllRelations()
                    .SingleAsync();
    public async Task UpdateFileAsync(FileModel item)
    {
        _dbContext.Entry(item).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateFolderAsync(Folder folder)
    {
        _dbContext.Entry(folder).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveFolderWithChildrenAsync(int folderId)
    {
   
        var folderToRemove = await _dbContext.Folders.Where(f => f.Id == folderId).SingleAsync();

        var descendats = await _dbContext
                                .Folders
                                .Where(x => x.Node.IsDescendantOf(folderToRemove.Node))
                                .Include(x => x.Files)
                                .ToListAsync();

        foreach (var descendat in descendats)
        { 
            descendat.Delete();
        }

        await _dbContext.SaveChangesAsync();
        
    }

}
