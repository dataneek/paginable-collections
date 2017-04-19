namespace PaginableCollections.Tests
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture, Category("PaginableRequest")]
    public class PaginableRequestTests
    {
        [Test]
        public void ShouldEqualPageNumber()
        {
            var expectedPageNumber = 2;
            var sut = new PaginableRequest(expectedPageNumber, 10);

            sut.PageNumber.ShouldBeEquivalentTo(expectedPageNumber);
        }

        [Test]
        public void ShouldEqualItemCountPerPage()
        {
            var expectedItemCountPerPage = 12;
            var sut = new PaginableRequest(2, expectedItemCountPerPage);

            sut.ItemCountPerPage.ShouldBeEquivalentTo(expectedItemCountPerPage);
        }
    }
}