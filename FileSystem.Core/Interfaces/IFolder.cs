using FileSystem.Core.FileSystem.Models;

namespace FileSystem.Core.Interfaces;

public interface IFolder : IBaseEntity<int>
{
    void Delete();


}
