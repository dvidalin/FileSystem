namespace FileSystem.Core.Exceptions;

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException(int itemId) : base($"No item found with ID {itemId}!")
    {

    }
}
