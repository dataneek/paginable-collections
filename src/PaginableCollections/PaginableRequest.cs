namespace PaginableCollections
{
    using System;
    using System.Linq;

    public class PaginableRequest : IPaginableRequest 
    {
        public PaginableRequest(int pageNumber, int itemCountPerPage)
        {
            this.PageNumber = pageNumber;
            this.ItemCountPerPage = itemCountPerPage;
        }

        public int PageNumber { get; private set; }
        public int ItemCountPerPage { get; private set; }
    }
}