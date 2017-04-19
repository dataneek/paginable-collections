namespace PaginableCollections.Tests
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture, Category("EmptyPaginable")]
    public class EmptyPaginableTests
    {
        [Test]
        public void ShouldEqualPageNumber()
        {
            var expectedPageNumber = 1;
            var sut = Paginable.Empty<int>();

            sut.PageNumber.ShouldBeEquivalentTo(expectedPageNumber);
        }

        [Test]
        public void ShouldEqualItemCountPerPage()
        {
            var expectedItemCountPerPage = EmptyPaginable<int>.DefaultItemCountPerPage;
            var sut = Paginable.Empty<int>();

            sut.ItemCountPerPage.ShouldBeEquivalentTo(expectedItemCountPerPage);
        }

        [Test]
        public void ShouldEqualTotalItemCount()
        {
            var expectedTotalItemCount = 0;
            var sut = Paginable.Empty<int>();

            sut.TotalItemCount.ShouldBeEquivalentTo(expectedTotalItemCount);
        }
    }
}