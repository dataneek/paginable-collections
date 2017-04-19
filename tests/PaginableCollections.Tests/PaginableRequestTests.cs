namespace PaginableCollections.Tests
{
    using FluentAssertions;
    using Xunit;

    public class PaginableRequestTests
    {
        [Fact]
        public void ShouldEqualPageNumber()
        {
            var expectedPageNumber = 2;
            var sut = new PaginableRequest(expectedPageNumber, 10);

            sut.PageNumber.ShouldBeEquivalentTo(expectedPageNumber);
        }

        [Fact]
        public void ShouldEqualItemCountPerPage()
        {
            var expectedItemCountPerPage = 12;
            var sut = new PaginableRequest(2, expectedItemCountPerPage);

            sut.ItemCountPerPage.ShouldBeEquivalentTo(expectedItemCountPerPage);
        }
    }
}