using FileSystem.Core.Interfaces;

namespace FileSystem.GrpcServer.ModelExtensions
{
    public static class FileSystemServiceExtensions
    {
        public static FolderReply GetFolderReply(this IFolder folder)
            => new()
            { 
                Id = folder.Id,
                Name = folder.Name,
                ParentFolderId = folder.ParentId ?? -1
            };

        public static FileReply GetFileReply(this IFile file)
            => new()
            {
                Id = file.Id,
                Name = file.Name,
                ParentFolderId = file.ParentFolderId
            };

    }
}
