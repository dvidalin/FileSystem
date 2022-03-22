namespace FileSystem.Core.Common;
public class PaginationResponse <T>
{
    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int FilteredCount { get; set; }

    public PaginationResponse(PaginationRequest request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
    }

    public PaginationResponse()
    {
    }
}
