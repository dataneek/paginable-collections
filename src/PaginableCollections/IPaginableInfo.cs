namespace PaginableCollections
{
    using System;
    using System.Linq;

    public interface IPaginableInfo
    {
        int PageNumber { get; }
        int ItemCountPerPage { get; }
    }
}