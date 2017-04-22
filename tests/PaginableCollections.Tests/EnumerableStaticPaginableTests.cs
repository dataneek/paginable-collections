namespace PaginableCollections.Tests
{
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class EnumerableStaticPaginableTests
    {
        [Fact]
        public void ShouldEqualPageNumber()
        {
            var source = Enumerable.Range(11, 20);
            var expectedPageNumber = 2;

            var sut = source.ToPaginable(expectedPageNumber, 10, 100);

            sut.PageNumber.ShouldBeEquivalentTo(expectedPageNumber);
        }

        [Fact]
        public void ShouldEqualItemCountPerPage()
        {
            var source = Enumerable.Range(11, 20);
            var expectedItemCountPerPage = 12;

            var sut = source.ToPaginable(2, expectedItemCountPerPage, 100);

            sut.ItemCountPerPage.ShouldBeEquivalentTo(expectedItemCountPerPage);
        }

        [Fact]
        public void ShouldEqualTotalItemCount()
        {
            var expectedTotalItemCount = 25;
            var source = Enumerable.Range(11, expectedTotalItemCount);

            var sut = source.ToPaginable(2, 10, expectedTotalItemCount);

            sut.TotalItemCount.ShouldBeEquivalentTo(expectedTotalItemCount);
        }
    }
}