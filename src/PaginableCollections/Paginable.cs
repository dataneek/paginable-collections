namespace PaginableCollections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Base class represents page of items.
    /// </summary>
    /// <typeparam name="T">The type of items in this paginable.</typeparam>
    public abstract class Paginable<T> : IPaginable<T>
    {
        protected readonly List<IPaginableItem<T>> innerList = new List<IPaginableItem<T>>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator<IPaginableItem<T>> IEnumerable<IPaginableItem<T>>.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        /// <summary>
        /// Total number of items.
        /// </summary>
        public int TotalItemCount { get; protected set; }

        /// <summary>
        /// Requested page number.
        /// </summary>
        public int PageNumber { get; protected set; }

        /// <summary>
        /// Requested number of items per page.
        /// </summary>
        public int ItemCountPerPage { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IPaginableItem<T> IPaginable<T>.this[int index] => innerList[index];

        /// <summary>
        /// Number of items in this result set.
        /// </summary>
        public int Count => innerList.Count;

        /// <summary>
        /// Total number of pages.
        /// </summary>
        public int TotalPageCount =>
            TotalItemCount > 0 ? (int)Math.Ceiling(TotalItemCount / (double)ItemCountPerPage) : 0;

        /// <summary>
        /// Identifies the first page.
        /// </summary>
        public bool IsFirstPage => PageNumber == 1;

        /// <summary>
        /// Identifies the last page.
        /// </summary>
        public bool IsLastPage => PageNumber >= TotalPageCount;

        /// <summary>
        /// Identifies if a previous page is available.
        /// </summary>
        public bool HasPreviousPage => PageNumber > 1;

        /// <summary>
        /// Identifies if a next page is available.
        /// </summary>
        public bool HasNextPage => PageNumber < TotalPageCount;

        /// <summary>
        /// Identifies the first item number of the page.
        /// </summary>
        public int FirstItemNumber { get; protected set; }

        /// <summary>
        /// Identifies the last item number of the page.
        /// </summary>
        public int LastItemNumber { get; protected set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public static class Paginable
    {
        /// <summary>
        /// Returns new empty paginable collection.
        /// </summary>
        /// <returns></returns>
        public static IPaginable<T> Empty<T>()
        {
            return new EmptyPaginable<T>();
        }
    }
}