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

            TotalItemCount = totalItemCount;
            PageNumber = pageNumber;
            ItemCountPerPage = itemCountPerPage;

            innerList.AddRange(subset.ToPaginableItemList(pageNumber, itemCountPerPage));

            if (innerList.Any())
            {
                FirstItemNumber = innerList.First().ItemNumber;
                LastItemNumber = innerList.Last().ItemNumber;
            }
            else
            {
                FirstItemNumber = 0;
                LastItemNumber = 0;
            }
        }
    }
}