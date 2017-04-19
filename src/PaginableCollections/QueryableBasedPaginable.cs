﻿namespace PaginableCollections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This paginable that uses the underlying data source to calculate pagination statistics.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueryableBasedPaginable<T> : Paginable<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="pageNumber"></param>
        /// <param name="itemCountPerPage"></param>
        public QueryableBasedPaginable(IQueryable<T> queryable, int pageNumber, int itemCountPerPage)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber));

            if (itemCountPerPage < 1)
                throw new ArgumentOutOfRangeException(nameof(ItemCountPerPage));

            this.TotalItemCount = queryable == null ? 0 : queryable.Count();
            this.PageNumber = pageNumber;
            this.ItemCountPerPage = itemCountPerPage;

            if (queryable != null && TotalItemCount > 0)
                innerList.AddRange(
                    pageNumber == 1
                        ? queryable.Skip(0).Take(ItemCountPerPage).ToPaginableItemList(pageNumber, itemCountPerPage)
                        : queryable.Skip((pageNumber - 1) * ItemCountPerPage).Take(ItemCountPerPage).ToPaginableItemList(pageNumber, itemCountPerPage));

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="superset"></param>
        /// <param name="pageNumber"></param>
        /// <param name="itemCountPerPage"></param>
        public QueryableBasedPaginable(IEnumerable<T> superset, int pageNumber, int itemCountPerPage)
            : this(superset.AsQueryable(), pageNumber, itemCountPerPage) { }
    }
}