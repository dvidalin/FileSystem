using FileSystem.Core.FileSystem.Models;
using FileSystem.EF.DbModels;

namespace FileSystem.EF.Adapters
{
    public static class FolderAdapter
    {
        public static FolderModel GetFolderModel(this FolderDbModel folder)
        {
            return new FolderModel 
            { 
                Name = folder.Name,
                Id = folder.Id
            };
        }

        public static FolderDbModel GetDbModel(this FolderModel folder)
        {
            return new FolderDbModel
            { 
                Name=folder.Name,
                Id=folder.Id
            };
        }
    }
}
