using FileSystem.EF.DbModels;
using Microsoft.EntityFrameworkCore;

namespace FileSystem.EF.QueryStore
{
    public static class FileQueryStore 
    {

        public static IQueryable<FileDbModel> FilesQuery(this FileSystemDbContext dbContext)
            => dbContext
                .Files
                .AsQueryable();

        public static IQueryable<FileDbModel> WithParentFolder(this IQueryable<FileDbModel> query)
            => query.Include(f => f.ParentFolder);

        public static IQueryable<FileDbModel> NameStartsWith(this IQueryable<FileDbModel> query, string searchString)
            => query.Where(f => f.Name.StartsWith(searchString));

        public static IQueryable<FileDbModel> ById(this IQueryable<FileDbModel> query, int id)
            => query.Where(f => f.Id == id);

        public static IQueryable<FileDbModel> Paginate(this IQueryable<FileDbModel> query, int page, int pageSize)
            => query.Skip(calculateSkip(page, pageSize)).Take(pageSize);

        private static int calculateSkip(int page, int pageSize)
            => (page - 1) * pageSize;
    }
}
