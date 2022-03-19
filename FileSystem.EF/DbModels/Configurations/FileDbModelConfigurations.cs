using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileSystem.EF.DbModels.Configurations;

public class FileDbModelConfigurations : IEntityTypeConfiguration<FileDbModel>
{
    public void Configure(EntityTypeBuilder<FileDbModel> builder)
    {
        builder.ToTable("Files");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        

        SetQueryFilters(builder);
    }

    private void SetQueryFilters(EntityTypeBuilder<FileDbModel> builder)
    {
        builder.HasQueryFilter(f => !f.IsDeleted);
    }

}
