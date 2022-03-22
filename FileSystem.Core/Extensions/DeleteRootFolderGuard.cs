
using FileSystem.Core.Exceptions;
using FileSystem.Core.FileSystem.Models;

namespace Ardalis.GuardClauses;
public static class DeleteRootFolderGuard {
    public static void DeleteRootFolder(this IGuardClause guardClause, Folder input)
    {
        if (input.IsRoot())
            throw new CantDeleteRootNodeException();

    }

}
