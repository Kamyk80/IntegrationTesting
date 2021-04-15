using System.Net;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static IntegrationTesting.TestCase;

namespace IntegrationTesting.Tests
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        public void ItShouldBePossibleToCreateGivenTestUsingConfiguration()
        {
            Given()
            .When()
                // Base address should be taken from configuration
                .Get("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.OK));
        }

        [TestMethod]
        public void ItShouldBePossibleToCreateWhenTestUsingConfiguration()
        {
            When()
                // Base address should be taken from configuration
                .Get("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.OK));
        }
    }
}
