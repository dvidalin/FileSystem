using Ardalis.GuardClauses;
using FileSystem.Core.Interfaces;

namespace FileSystem.Core.Common;

public abstract class BaseEntity<TId> : IBaseEntity<TId>
    where TId : struct
{
    public TId Id { get; set; }
    public string Name { get; set; }

    public BaseEntity(string name)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
    }
}
