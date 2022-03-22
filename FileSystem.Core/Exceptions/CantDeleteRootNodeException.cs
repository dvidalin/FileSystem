namespace FileSystem.Core.Exceptions;
public class CantDeleteRootNodeException : Exception
{
    public CantDeleteRootNodeException() : base($"Root folder would be deleted!")
    {

    }

}
