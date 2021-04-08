using System;
using System.Net;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static IntegrationTesting.TestCase;

namespace IntegrationTesting.Tests
{
    [TestClass]
    public class PatchTest
    {
        [TestMethod]
        public void ItShouldBePossibleToCreatePatchStringTest()
        {
            Given()
                .BaseAddress("https://reqres.in")
                .Timeout(TimeSpan.FromSeconds(10))
                .Header("Accept", "application/json")
                .Content("{\"name\":\"morpheus\",\"job\":\"zion resident\"}")
            .When()
                .Patch("/api/users/2")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.OK));
        }
    }
}
