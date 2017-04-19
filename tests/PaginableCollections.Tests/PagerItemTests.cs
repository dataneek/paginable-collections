namespace PaginableCollections.Facts
{
    using FluentAssertions;
    using Xunit;

    public class StaticPagerPageFacts
    {
        [Fact]
        public void ShouldSetPageNumber()
        {
            var pageNumber = 1;
            var sut = new PagerItem(pageNumber, 10);

            sut.PageNumber.ShouldBeEquivalentTo(pageNumber);
        }

        [Fact]
        public void ShouldSetIsFirstPage()
        {
            var pageNumber = 1;
            var sut = new PagerItem(pageNumber, 10);

            sut.IsFirstPage.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void ShouldSetIsPreviousPage()
        {
            var pageNumber = 1;
            var sut = new PagerItem(pageNumber, 10);

            sut.HasPreviousPage.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void ShouldSetHasNextPage()
        {
            var pageNumber = 1;
            var sut = new PagerItem(pageNumber, 10);

            sut.HasNextPage.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void ShouldSetTotalPageCount()
        {
            var totalPageCount = 1;
            var sut = new PagerItem(1, totalPageCount);

            sut.TotalPageCount.ShouldBeEquivalentTo(totalPageCount);
        }

        [Fact]
        public void ShouldBeLastPage()
        {
            var totalPageCount = 10;
            var sut = new PagerItem(totalPageCount, totalPageCount);

            sut.IsLastPage.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void ShouldBeHasNextPage()
        {
            var totalPageCount = 10;
            var sut = new PagerItem(totalPageCount, totalPageCount);

            sut.HasNextPage.ShouldBeEquivalentTo(false);
        }
    }
}
