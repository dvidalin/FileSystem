
namespace FileSystem.Core.Exceptions;
public class InvalidCharacterException : Exception
{
    public InvalidCharacterException(List<char> invalidChars) : base($"Invalid characters in name: {string.Join(", ", invalidChars)}!")
    {
    }
}
