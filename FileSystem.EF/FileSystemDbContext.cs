using FileSystem.Core.Interfaces;
using FileSystem.EF.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
        public virtual DbSet<FileDbModel> Files { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FileSystemDbContext).Assembly);

        }

        //public override int SaveChanges(bool acceptAllChangesOnSuccess)
        //{
        //    OnBeforeSave();
        //    return base.SaveChanges(acceptAllChangesOnSuccess);
        //}

        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    OnBeforeSave();
        //    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken); 
        //}

        //private void OnBeforeSave()
        //{
        //    var entries = ChangeTracker
        //        .Entries();

        //    foreach (var entry in entries)
        //    {
        //        if (ShouldSoftDelete(entry))
        //            SoftDelete(entry);

        //        if (entry.State == EntityState.Modified && entry is IChangeHistoryEntity)
        //        { 
        //            var changeTrackerEntity = entry.Entity as IChangeHistoryEntity;
        //            changeTrackerEntity!.DateModified = DateTime.UtcNow;
        //        }
        //    }
        //}

        //private bool ShouldSoftDelete(EntityEntry entry)
        //{
        //    return entry.State == EntityState.Deleted && entry is ISoftDeleteEntity;
        //}

        //private EntityEntry SoftDelete(EntityEntry entry)
        //{

        //    entry.State = EntityState.Modified;
        //    (entry.Entity as ISoftDeleteEntity)!.IsDeleted = true;

        //    if (entry.Entity is IHasParent)
        //    { 
        //        (entry.Entity as IHasParent).
        //    }

        //    return entry;
        //}
    }
}
