using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.EF.DbModels.Configurations
{
    public class FolderDbModelConfigurations : IEntityTypeConfiguration<FolderDbModel>
    {
        public void Configure(EntityTypeBuilder<FolderDbModel> builder)
        {
            
            builder.ToTable("Folders");

            builder.HasOne(f => f.Parent)
                .WithMany(f => f.Subfolders)
                .HasForeignKey(f => f.ParentId)
                .IsRequired(false);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Level)
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(x => x.Name)
                .HasMaxLength(32);

            builder.HasMany(x => x.Files)
                .WithOne(x => x.ParentFolder)
                .HasForeignKey(x => x.ParentFolderId);

            SetQueryFilters(builder);
        }

        private void SetQueryFilters(EntityTypeBuilder<FolderDbModel> builder)
        {
            builder.HasQueryFilter(f => !f.IsDeleted);
        }
    }
}
