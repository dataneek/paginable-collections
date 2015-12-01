namespace PaginableCollections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StaticPaginable<T> : Paginable<T>
    {
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