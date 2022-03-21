using FileSystem.Core.Common;
using FileSystem.Core.FileSystem.Interfaces;
using FileSystem.Core.Interfaces;
using FileSystem.EF.DbModels;
using FileSystem.EF.QueryStore;
using Microsoft.EntityFrameworkCore;

namespace FileSystem.EF;
public class FileServerRepository : IFileServerRepository<FolderDbModel, FileDbModel>
{
    private readonly FileSystemDbContext _dbContext;

    public FileServerRepository(FileSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<FileDbModel> AddFileAsync(FileDbModel file)
    {
        _dbContext.Files.Add(file);

        await _dbContext.SaveChangesAsync();

        return file;
    }
    public async Task AddFolderAsync(FolderDbModel folder)
    { 
        _dbContext.Folders.Add(folder); 

        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<FolderDbModel>> GetAllAsync()
        => await _dbContext.Folders.ToListAsync();
    public async Task<FileDbModel> GetFileByIdAsync(int fileId)     
        => await _dbContext
                    .FilesQuery()
                    .ById(fileId)
                    .SingleAsync();

    public async Task<PaginationResponse<FileDbModel>> GetFilesPaginatedAsync(PaginationRequest request)
    {
        PaginationResponse<FileDbModel> response = new(request);

        try
        {
            var query = _dbContext
                            .FilesQuery()
                            .SetSearchFilters(request.SearchString);

            response.FilteredCount = await query.CountAsync();
            response.Items = query.Paginate(request.PageNumber, request.PageSize);

            response.TotalCount = await _dbContext.Files.CountAsync();


        }
        catch (Exception ex) {
            var t = 5;
        }


        return response;

    }
    public async Task<FolderDbModel> GetFolderByIdAsync(int folderId)
        => await _dbContext
                    .FoldersQuery()
                    .ById(folderId)
                    .WithAllRelations()
                    .SingleAsync();
    public async Task<FolderDbModel> GetFolderWithDeletedChildredByIdAsync(int folderId) 
        => await _dbContext
                    .FoldersQuery()
                    .IgnoreQueryFilters()
                    .Where(f => !f.IsDeleted)
                    .ById(folderId)                    
                    .WithAllRelations()
                    .SingleAsync();
    public async Task UpdateFileAsync(FileDbModel item)
    { 
        _dbContext.Entry(item).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateFolderAsync(FolderDbModel folder)
    { 
        _dbContext.Entry(folder).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

}
