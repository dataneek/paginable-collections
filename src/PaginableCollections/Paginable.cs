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
        protected readonly List<T> innerList = new List<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
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
        public T this[int index] { get { return innerList[index]; } }

        /// <summary>
        /// Number of items in this result set.
        /// </summary>
        public int Count { get { return innerList.Count; } }

        /// <summary>
        /// Total number of pages.
        /// </summary>
        public int TotalPageCount
        {
            get
            {
                return
                    TotalItemCount > 0
                        ? (int)Math.Ceiling(TotalItemCount / (double)this.ItemCountPerPage)
                        : 0;
            }
        }

        /// <summary>
        /// Identifies the first page.
        /// </summary>
        public bool IsFirstPage { get { return PageNumber == 1; } }

        /// <summary>
        /// Identifies the last page.
        /// </summary>
        public bool IsLastPage { get { return PageNumber >= TotalPageCount; } }

        /// <summary>
        /// Identifies if a previous page is available.
        /// </summary>
        public bool HasPreviousPage { get { return PageNumber > 1; } }

        /// <summary>
        /// Identifies if a next page is available.
        /// </summary>
        public bool HasNextPage { get { return PageNumber < TotalPageCount; } }
    }
}