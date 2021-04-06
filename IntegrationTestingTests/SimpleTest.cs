using System.Net;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static IntegrationTesting.TestCase;

namespace IntegrationTestingTests
{
    [TestClass]
    public class SimpleTest
    {
        [TestMethod]
        public void ItShouldBePossibleToCreateSimpleTest()
        {
            Given()
            .When()
                .Get("https://reqres.in/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.OK));
        }
    }
}
