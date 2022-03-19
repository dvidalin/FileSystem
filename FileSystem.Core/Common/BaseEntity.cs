using FileSystem.Core.Interfaces;

namespace FileSystem.Core.Common;

public abstract class BaseEntity<TId> : IBaseEntity<TId>
{
    public TId Id { get; set; }
    public string Name { get; set; }
}
