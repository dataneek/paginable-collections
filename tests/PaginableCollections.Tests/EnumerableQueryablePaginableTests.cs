namespace PaginableCollections.Tests
{
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class EnumerableQueryablePaginableTests
    {
        [Fact]
        public void ShouldEqualPageNumber()
        {
            var source = Enumerable.Range(10, 50);
            var expectedPageNumber = 2;

            var sut = source.ToPaginable(expectedPageNumber, itemCountPerPage: 10);

            sut.PageNumber.ShouldBeEquivalentTo(expectedPageNumber);
        }

        [Fact]
        public void ShouldEqualItemCountPerPage()
        {
            var source = Enumerable.Range(11, 100);
            var expectedItemCountPerPage = 12;

            var sut = source.ToPaginable(2, expectedItemCountPerPage);

            sut.ItemCountPerPage.ShouldBeEquivalentTo(expectedItemCountPerPage);
        }

        [Fact]
        public void ShouldEqualTotalItemCount()
        {
            var expectedTotalItemCount = 25;
            var source = Enumerable.Range(11, expectedTotalItemCount);

            var sut = source.ToPaginable(2, 10);

            sut.TotalItemCount.ShouldBeEquivalentTo(expectedTotalItemCount);
        }
    }
}