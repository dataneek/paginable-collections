namespace PaginableCollections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Paginable<T> : IPaginable<T>
    {
        protected readonly List<T> innerList = new List<T>();

        public IEnumerator<T> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        public int TotalItemCount { get; protected set; }

        public int PageNumber { get; protected set; }

        public int ItemCountPerPage { get; protected set; }

        public T this[int index] { get { return innerList[index]; } }

        public int Count { get { return innerList.Count; } }

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

        public bool IsFirstPage { get { return PageNumber == 1; } }

        public bool IsLastPage { get { return PageNumber >= TotalPageCount; } }

        public bool HasPreviousPage { get { return PageNumber > 1; } }

        public bool HasNextPage { get { return PageNumber < TotalPageCount; } }
    }
}