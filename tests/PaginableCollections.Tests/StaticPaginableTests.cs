namespace PaginableCollections.Facts
{
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class StaticPaginableFacts
    {
        [Fact]
        public void ShouldEqualPageNumber()
        {
            var source = Enumerable.Range(11, 20);
            var expectedPageNumber = 2;

            IPaginable<int> sut = new StaticPaginable<int>(source, expectedPageNumber, 10, 100);

            sut.PageNumber.ShouldBeEquivalentTo(expectedPageNumber);
        }

        [Fact]
        public void ShouldEqualItemCountPerPage()
        {
            var source = Enumerable.Range(11, 20);
            var expectedItemCountPerPage = 12;

            var sut = new StaticPaginable<int>(source, 2, expectedItemCountPerPage, 100);

            sut.ItemCountPerPage.ShouldBeEquivalentTo(expectedItemCountPerPage);
        }

        [Fact]
        public void ShouldEqualTotalItemCount()
        {
            var expectedTotalItemCount = 25;
            var source = Enumerable.Range(11, expectedTotalItemCount);

            var sut = new StaticPaginable<int>(source, 2, 10, expectedTotalItemCount);

            sut.TotalItemCount.ShouldBeEquivalentTo(expectedTotalItemCount);
        }

        [Fact]
        public void ShouldEqualFirstElementNextPage()
        {
            var source = Enumerable.Range(1, 100);
            var paginable = new StaticPaginable<int>(source, 3, 10, 100);

            var sut = paginable.ElementAt(0);

            sut.ItemNumber.ShouldBeEquivalentTo(21);
            sut.Item.ShouldBeEquivalentTo(1);
            sut.PageNumber.ShouldBeEquivalentTo(3);
            sut.ItemCountPerPage.ShouldBeEquivalentTo(10);
        }
    }
}