using FileSystem.Core.FileSystem.Models;
using FileSystem.Core.Interfaces;
using FileSystem.EF.DbModels;
using Microsoft.EntityFrameworkCore;


namespace FileSystem.EF
{
    public class FolderRepository : IFolderRepository
    {
        private readonly FileSystemDbContext _dbContext;

        public FolderRepository(FileSystemDbContext systemContext)
        {
            _dbContext = systemContext;
        }

        public void Add(string name, int? parentId)
        {
            var node = GetNewUniqueNode(parentId);

            Add(new FolderDbModel(name, node));

        }

        public void AddToRoot(string name)
        {
            Add(name, null);
        }

        IEnumerable<FolderModel> IFolderRepository.GetAll()
        {
            var folders = _dbContext.Folders;

            throw new Exception();

        }

        private void Add(FolderDbModel folderDbModel)
        { 
            _dbContext.Add(folderDbModel);
            _dbContext.SaveChanges();
        }

        private HierarchyId GetNewUniqueNode(int? parentFolderId)
        {
            HierarchyId parentFolderNode;
            if (parentFolderId.HasValue)
                parentFolderNode = GetFolderNodeById(parentFolderId.Value);
            else
                parentFolderNode = HierarchyId.GetRoot();

            var maxChildNode = GetMaxChildNode(parentFolderNode);
            return parentFolderNode.GetDescendant(maxChildNode, null);
        }

        private HierarchyId GetFolderNodeById(int folderId)
        {
            return _dbContext
                .Folders
                .Where(f => f.Id == folderId)
                .Select(f => f.Node)
                .First();
        }

        private HierarchyId GetMaxChildNode(HierarchyId parentFolderNode)
        {
#pragma warning disable CS8603 // Possible null reference return. 
            return _dbContext
                .Folders
                .Where(f => f.Node.GetAncestor(1).Equals(parentFolderNode))
                .OrderByDescending(f => f.Node)
                .Select(f => f.Node)
                .FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.


        }
        

    }


}