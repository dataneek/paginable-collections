namespace PaginableCollections
{
	public class PaginableRequest : IPaginableRequest 
    {
        public PaginableRequest(int pageNumber, int itemCountPerPage)
        {
            PageNumber = pageNumber;
            ItemCountPerPage = itemCountPerPage;
        }

        public int PageNumber { get; private set; }
        public int ItemCountPerPage { get; private set; }
    }
}