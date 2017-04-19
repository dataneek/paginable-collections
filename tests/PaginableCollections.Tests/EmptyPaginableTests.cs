namespace PaginableCollections.Tests
{
    using FluentAssertions;
    using Xunit;

    public class EmptyPaginableTests
    {
        [Fact]
        public void ShouldEqualPageNumber()
        {
            var expectedPageNumber = 1;
            var sut = Paginable.Empty<int>();

            sut.PageNumber.ShouldBeEquivalentTo(expectedPageNumber);
        }

        [Fact]
        public void ShouldEqualItemCountPerPage()
        {
            var expectedItemCountPerPage = EmptyPaginable<int>.DefaultItemCountPerPage;
            var sut = Paginable.Empty<int>();

            sut.ItemCountPerPage.ShouldBeEquivalentTo(expectedItemCountPerPage);
        }

        [Fact]
        public void ShouldEqualTotalItemCount()
        {
            var expectedTotalItemCount = 0;
            var sut = Paginable.Empty<int>();

            sut.TotalItemCount.ShouldBeEquivalentTo(expectedTotalItemCount);
        }
    }
}