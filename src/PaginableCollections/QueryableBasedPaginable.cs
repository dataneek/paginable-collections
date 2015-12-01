namespace PaginableCollections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class QueryableBasedPaginable<T> : Paginable<T>
    {
        public QueryableBasedPaginable(IQueryable<T> queryable, int pageNumber, int itemCountPerPage)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber");

            if (itemCountPerPage < 1)
                throw new ArgumentOutOfRangeException("itemCountPerPage");

            this.TotalItemCount = queryable == null ? 0 : queryable.Count();
            this.PageNumber = pageNumber;
            this.ItemCountPerPage = itemCountPerPage;

            if (queryable != null && TotalItemCount > 0)
                innerList.AddRange(
                    pageNumber == 1
                        ? queryable.Skip(0).Take(ItemCountPerPage).ToList()
                        : queryable.Skip((pageNumber - 1) * ItemCountPerPage).Take(ItemCountPerPage).ToList());
        }

        public QueryableBasedPaginable(IEnumerable<T> superset, int pageNumber, int itemCountPerPage)
            : this(superset.AsQueryable(), pageNumber, itemCountPerPage) { }
    }
}