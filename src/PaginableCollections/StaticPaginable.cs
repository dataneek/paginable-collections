namespace PaginableCollections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Encapsulates a collection of data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StaticPaginable<T> : Paginable<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subset"></param>
        /// <param name="pageNumber"></param>
        /// <param name="itemCountPerPage"></param>
        /// <param name="totalItemCount"></param>
        public StaticPaginable(IEnumerable<T> subset, int pageNumber, int itemCountPerPage, int totalItemCount)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber");

            if (itemCountPerPage < 1)
                throw new ArgumentOutOfRangeException("itemCountPerPage");

            this.TotalItemCount = totalItemCount;
            this.PageNumber = pageNumber;
            this.ItemCountPerPage = itemCountPerPage;

            this.innerList.AddRange(subset);
        }
    }
}