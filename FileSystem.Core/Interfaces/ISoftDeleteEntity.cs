namespace FileSystem.Core.Interfaces;

public interface ISoftDeleteEntity
{
    bool IsDeleted { get; set; }
}
