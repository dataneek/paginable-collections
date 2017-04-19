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
                throw new ArgumentOutOfRangeException(nameof(pageNumber));

            if (itemCountPerPage < 1)
                throw new ArgumentOutOfRangeException(nameof(itemCountPerPage));

            if (subset.Count() > totalItemCount)
                throw new ArgumentOutOfRangeException(nameof(totalItemCount));

            this.TotalItemCount = totalItemCount;
            this.PageNumber = pageNumber;
            this.ItemCountPerPage = itemCountPerPage;

            this.innerList.AddRange(subset.ToPaginableItemList(pageNumber, itemCountPerPage));

            if (innerList.Any())
            {
                this.FirstItemNumber = innerList.First().ItemNumber;
                this.LastItemNumber = innerList.Last().ItemNumber;
            }
            else
            {
                this.FirstItemNumber = 0;
                this.LastItemNumber = 0;
            }
        }
    }
}