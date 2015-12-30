namespace PaginableCollections
{ 
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Non-generic contract representing a page of data.
    /// </summary>
    public interface IPaginable
    {
        /// <summary>
        /// Total number of pages.
        /// </summary>
        int TotalPageCount { get; }

        /// <summary>
        /// Total item count.
        /// </summary>
        int TotalItemCount { get; }

        /// <summary>
        /// Current page number.
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// Requested item count per page.
        /// </summary>
        int ItemCountPerPage { get; }

        /// <summary>
        /// 
        /// </summary>
        bool IsFirstPage { get; }

        /// <summary>
        /// 
        /// </summary>
        bool IsLastPage { get; }

        /// <summary>
        /// 
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// 
        /// </summary>
        bool HasNextPage { get; }
    }

    /// <summary>
    /// Generic contract representing a page of data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPaginable<out T> : IEnumerable<T>, IPaginable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T this[int index] { get; }

        /// <summary>
        /// Number of items in this paginable.
        /// </summary>
        int Count { get; }
    }
}