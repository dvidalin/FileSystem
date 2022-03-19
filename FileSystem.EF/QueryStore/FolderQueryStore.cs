

using FileSystem.EF.DbModels;
using Microsoft.EntityFrameworkCore;

namespace FileSystem.EF.QueryStore
{
    public static class FolderQueryStore
    {

        public static IQueryable<FolderDbModel> FoldersQuery(this FileSystemDbContext dbContext)
            => dbContext
                .Folders
                .AsQueryable();      

        public static IQueryable<FolderDbModel> WithParent(this IQueryable<FolderDbModel> query)
            => query.Include(x => x.Parent);

        public static IQueryable<FolderDbModel> WithChildren(this IQueryable<FolderDbModel> query)
            => query.Include(x => x.Subfolders);
        public static IQueryable<FolderDbModel> WithFolders(this IQueryable<FolderDbModel> query)
            => query.Include(f => f.Files);
        public static IQueryable<FolderDbModel> WithAllRelations(this IQueryable<FolderDbModel> query)
            => query
                    .WithChildren()
                    .WithParent()
                    .WithFolders();
        public static IQueryable<FolderDbModel> IncludeDeleted(this IQueryable<FolderDbModel> query)
            => query.IgnoreQueryFilters();

        public static IQueryable<FolderDbModel> ById(this IQueryable<FolderDbModel> query, int folderId)
            => query.Where(f => f.Id == folderId);

        public static IQueryable<FolderDbModel> IsRootNode(this IQueryable<FolderDbModel> query)
            => query.Where(f => f.Node == HierarchyId.GetRoot());

        public static IQueryable<FolderDbModel> IsDescendantOf(this IQueryable<FolderDbModel> query, FolderDbModel folder)
            => query.Where(f => f.Node.IsDescendantOf(folder.Node));

    }
}
