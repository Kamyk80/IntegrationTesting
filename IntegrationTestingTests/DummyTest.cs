using Microsoft.VisualStudio.TestTools.UnitTesting;
using static IntegrationTesting.TestCase;

namespace IntegrationTestingTests
{
    [TestClass]
    public class DummyTest
    {
        [TestMethod]
        public void ItShouldBePossibleToCreateEmptyTest()
        {
            Given()
            .When()
                .Get()
            .Then();
        }
    }
}
