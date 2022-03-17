using FileSystem.Core.FileSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FileSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<FileModel> Files { get; set; }
        public DbSet<FolderModel> Folders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly();
        }
    }
}
