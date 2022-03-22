using Ardalis.GuardClauses;
using FileSystem.Core.Common;
using FileSystem.Core.Interfaces;

namespace FileSystem.Core.FileSystem.Models;
public class FileModel : BaseEntity<int>, IFile
{
    public FileModel(string fileName): base(fileName)
    {   
        Name = Guard.Against.InvalidCharacter(fileName, nameof(fileName));
    }

    public virtual void Delete() => throw new NotImplementedException();
}
