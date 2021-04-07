using System;
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
        public void ItShouldBePossibleToCreateGivenTest()
        {
            Given()
                .BaseAddress("https://reqres.in")
                .Timeout(TimeSpan.FromSeconds(10))
                .Header("Accept", "application/json")
            .When()
                .Get("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.OK));
        }

        [TestMethod]
        public void ItShouldBePossibleToCreateGivenTestWithExpressions()
        {
            Given()
                .Client(client => client.BaseAddress = new Uri("https://reqres.in"))
                .Client(client => client.Timeout = TimeSpan.FromSeconds(10))
                .Message(message => message.Headers.Add("Accept", "application/json"))
            .When()
                .Get("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.OK));
        }

        [TestMethod]
        public void ItShouldBePossibleToCreateWhenTest()
        {
            When()
                .Get("https://reqres.in/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.OK));
        }
    }
}
