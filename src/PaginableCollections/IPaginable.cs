namespace PaginableCollections
{ 
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Non-generic contract representing a page of data.
    /// </summary>
    public interface IPaginable : IEnumerable
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
        /// Identifies the first page.
        /// </summary>
        bool IsFirstPage { get; }

        /// <summary>
        /// Identifies the last page.
        /// </summary>
        bool IsLastPage { get; }

        /// <summary>
        /// Identifies if there is a previous page.
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Identifies if there is a next page.
        /// </summary>
        bool HasNextPage { get; }

        /// <summary>
        /// The first item number of the page.
        /// </summary>
        int FirstItemNumber { get; }

        /// <summary>
        /// The last item number of this page.
        /// </summary>
        int LastItemNumber { get; }
    }

    /// <summary>
    /// Generic contract representing a page of data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPaginable<T> : IEnumerable<IPaginableItem<T>>, IPaginable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IPaginableItem<T> this[int index] { get; }

        /// <summary>
        /// Number of items in this paginable.
        /// </summary>
        int Count { get; }
    }
}