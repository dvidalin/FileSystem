namespace FileSystem.Core.Interfaces;
public interface IParentFolder<TFolder> : IFolder
    where TFolder : IFolder
{
    ICollection<TFolder> Subfolders { get; }

}
