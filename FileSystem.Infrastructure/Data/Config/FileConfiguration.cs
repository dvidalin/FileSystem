using FileSystem.Core.FileSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Infrastructure.Data.Config
{
    public class FileConfiguration : IEntityTypeConfiguration<FileModel>
    {
        public void Configure(EntityTypeBuilder<FileModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(255)
                .IsRequired();

            
        }
    }
}
