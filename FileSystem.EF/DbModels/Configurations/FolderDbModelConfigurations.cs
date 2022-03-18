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
            builder.ToTable("FolderOrg");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Level)
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(x => x.Name)
                .HasMaxLength(32);
                
        }
    }
}
