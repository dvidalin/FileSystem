﻿namespace FileSystem.Core.Common;
public class PaginationRequest 
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; } 
}
