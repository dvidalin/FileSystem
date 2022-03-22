
using FileSystem.Core.Exceptions;

namespace Ardalis.GuardClauses;
public static class InvalidCharacterGuard 
{
    private static readonly IEnumerable<char> InvalidCharacters = Path.GetInvalidFileNameChars();
    public static string InvalidCharacter(this IGuardClause guardClause, string input, string parameterName)
    { 
        var invalidChars = InvalidCharacters.Where(invalidChar => input.Contains(invalidChar));

        if (invalidChars.Any())
            throw new InvalidCharacterException(invalidChars.ToList());

        return input;
            
    }

}
