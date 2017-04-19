namespace PaginableCollections.Tests
{
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class StaticPagerTest
    {
        [Test]
        public void ShouldNotBeNull()
        {
            var sut = Enumerable.Range(1, 10).ToPaginable(1, 5).ToPager(2);
        }
    }
}