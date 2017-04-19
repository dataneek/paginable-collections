namespace PaginableCollections
{
    using System;
    using System.Linq;

    public interface IPaginableRequest
    {
        int PageNumber { get; }
        int ItemCountPerPage { get; }
    }
}