using System;
using System.Net;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static IntegrationTesting.TestCase;

namespace IntegrationTesting.Tests
{
    [TestClass]
    public class DeleteTest
    {
        [TestMethod]
        public void ItShouldBePossibleToCreateDeleteTest()
        {
            Given()
                .BaseAddress("https://reqres.in")
                .Timeout(TimeSpan.FromSeconds(10))
                .Header("Accept", "application/json")
            .When()
                .Delete("/api/users/2")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.NoContent));
        }
    }
}
