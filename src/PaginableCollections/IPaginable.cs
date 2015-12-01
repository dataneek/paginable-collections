namespace PaginableCollections
{ 
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IPaginable
    {
        int TotalPageCount { get; }
        int TotalItemCount { get; }
        int PageNumber { get; }
        int ItemCountPerPage { get; }

        bool IsFirstPage { get; }
        bool IsLastPage { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }

    public interface IPaginable<out T> : IEnumerable<T>, IPaginable
    {
        T this[int index] { get; }
        int Count { get; }
    }
}