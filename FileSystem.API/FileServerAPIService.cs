using FileSystem.Core.FileSystem.Interfaces;
using FileSystem.Core.Interfaces;
using Ardalis.GuardClauses;
using FileSystem.Core.Common;
using FileSystem.EF.DbModels;

namespace FileSystem.API;
public class FileServerAPIService : IFileServerAPIService
{
    private readonly IFileServerRepository _fileServerRepository;

    public FileServerAPIService(IFileServerRepository fileServerRepository)
    {
        _fileServerRepository = fileServerRepository;
    }

    public async Task<int> AddFileAsync(string fileName, int parentFolderId) { 
        var parentFolder = await _fileServerRepository.GetFolderByIdAsync(parentFolderId);

        var newFile = parentFolder.CreateFile(fileName);

        return await _fileServerRepository.AddFileAsync(newFile);

    }

    public async Task<int> AddFolderAsync(string folderName, int parentFolderId) {
        var parentFolder = await _fileServerRepository.GetFolderWithDeletedChildredByIdAsync(parentFolderId);

        var folderToAdd = parentFolder.AddSubfolder(folderName);

        return await _fileServerRepository.AddFolderAsync(folderToAdd);
    }

    public async Task<PaginationResponse<IFile>> FileLookupAsync(PaginationRequest request)
    {
        var t =await _fileServerRepository.GetFilesPaginatedAsync(request);

        return new PaginationResponse<IFile>();
    }
    public async Task RemoveFileByIdAsync(int fileId)
    {
        var fileToRemove = await _fileServerRepository.GetFileByIdAsync(fileId);

        fileToRemove.Delete();

        await _fileServerRepository.UpdateFileAsync(fileToRemove);
    }
    public async Task RemoveFolderByIdAsync(int folderId) => await _fileServerRepository.RemoveFolderWithChildrenAsync(folderId);
}
