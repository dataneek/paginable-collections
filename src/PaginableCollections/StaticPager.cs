namespace PaginableCollections
{
    using System.Collections.Generic;
    using System.Linq;

    public class StaticPager : IPager
    {
        private readonly IList<IPagerItem> pages;

        public StaticPager(IPaginable paginable, int maximumPageNumberCount)
        {
            this.MaximumPageNumberCount = maximumPageNumberCount;
            this.TotalPageCount = paginable.TotalPageCount;

            var firstPageToDisplay = 1;
            var lastPageToDisplay = paginable.TotalPageCount;
            var pageNumbersToDisplay = lastPageToDisplay;

            if (paginable.TotalPageCount > maximumPageNumberCount)
            {
                var maxPageNumbersToDisplay = maximumPageNumberCount;
                firstPageToDisplay = (paginable.PageNumber - maxPageNumbersToDisplay) / 2;
                if (firstPageToDisplay < 1)
                {
                    firstPageToDisplay = 1;
                }
                pageNumbersToDisplay = maxPageNumbersToDisplay;
                lastPageToDisplay = firstPageToDisplay + pageNumbersToDisplay - 1;
                if (lastPageToDisplay > paginable.TotalPageCount)
                {
                    firstPageToDisplay = paginable.TotalPageCount - maxPageNumbersToDisplay + 1;
                }
            }

            var totalPageNumber = paginable.TotalPageCount;
            if (totalPageNumber == 0)
            {
                totalPageNumber = 1;
            }

            pages = new List<IPagerItem>();

            for (int i = firstPageToDisplay; i <= firstPageToDisplay + pageNumbersToDisplay - 1; i++)
            {
                pages.Add(new PagerItem(i, totalPageNumber));
            }
        }

        IEnumerable<IPagerItem> IPager.GetPages()
        {
            return pages;
        }

        public int TotalPageCount { get; private set; }
        public int MaximumPageNumberCount { get; private set; }
    }
}