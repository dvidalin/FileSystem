using FileSystem.EF.DbModels;
using Microsoft.EntityFrameworkCore;

namespace FileSystem.EF
{
    public partial class FileSystemDbContext : DbContext
    {
        public FileSystemDbContext()
        {

        }

        public FileSystemDbContext(DbContextOptions<FileSystemDbContext> options)
            :base(options)
        {

        }

        public virtual DbSet<FolderDbModel> Folders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FileSystemDbContext).Assembly);

        }

    }
}
