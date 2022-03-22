using Ardalis.GuardClauses;

namespace FileSystem.Core.Common;
public class PaginationRequest 
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }

    public PaginationRequest(string searchString, int page, int size)
    {
        SearchString = Guard.Against.NullOrWhiteSpace(searchString, nameof(searchString));
        PageSize = Guard.Against.NegativeOrZero(size, nameof(size));    
        PageNumber = Guard.Against.NegativeOrZero(page, nameof(page));
    }
}
