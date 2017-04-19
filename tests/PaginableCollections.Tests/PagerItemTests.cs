namespace PaginableCollections.Tests
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class StaticPagerPageTests
    {
        [Test]
        public void ShouldSetPageNumber()
        {
            var pageNumber = 1;
            var sut = new PagerItem(pageNumber, 10);

            sut.PageNumber.ShouldBeEquivalentTo(pageNumber);
        }

        [Test]
        public void ShouldSetIsFirstPage()
        {
            var pageNumber = 1;
            var sut = new PagerItem(pageNumber, 10);

            sut.IsFirstPage.ShouldBeEquivalentTo(true);
        }

        [Test]
        public void ShouldSetIsPreviousPage()
        {
            var pageNumber = 1;
            var sut = new PagerItem(pageNumber, 10);

            sut.HasPreviousPage.ShouldBeEquivalentTo(false);
        }

        [Test]
        public void ShouldSetHasNextPage()
        {
            var pageNumber = 1;
            var sut = new PagerItem(pageNumber, 10);

            sut.HasNextPage.ShouldBeEquivalentTo(true);
        }

        [Test]
        public void ShouldSetTotalPageCount()
        {
            var totalPageCount = 1;
            var sut = new PagerItem(1, totalPageCount);

            sut.TotalPageCount.ShouldBeEquivalentTo(totalPageCount);
        }

        [Test]
        public void ShouldBeLastPage()
        {
            var totalPageCount = 10;
            var sut = new PagerItem(totalPageCount, totalPageCount);

            sut.IsLastPage.ShouldBeEquivalentTo(true);
        }

        [Test]
        public void ShouldBeHasNextPage()
        {
            var totalPageCount = 10;
            var sut = new PagerItem(totalPageCount, totalPageCount);

            sut.HasNextPage.ShouldBeEquivalentTo(false);
        }
    }
}
