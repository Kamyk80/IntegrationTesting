using System;
using System.Net;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static IntegrationTesting.TestCase;

namespace IntegrationTesting.Tests
{
    [TestClass]
    public class GetTest
    {
        [TestMethod]
        public void ItShouldBePossibleToCreateGetTest()
        {
            Given()
                .BaseAddress("https://reqres.in")
                .Timeout(TimeSpan.FromSeconds(10))
                .Header("Accept", "application/json")
            .When()
                .Get("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.OK))
                .Header("Access-Control-Allow-Origin", values => values.Should().Contain("*"))
                .ContentHeader("Content-Type", values => values.Should().Contain("application/json; charset=utf-8"))
                .JsonObject(json => ((int) json.page).Should().Be(1));
        }

        [TestMethod]
        public void ItShouldBePossibleToCreateGetTestUsingMessages()
        {
            Given()
                .Client(client => client.BaseAddress = new Uri("https://reqres.in"))
                .Client(client => client.Timeout = TimeSpan.FromSeconds(10))
                .Message(message => message.Headers.Add("Accept", "application/json"))
            .When()
                .Get("/api/users")
            .Then()
                .Message(message => message.Headers.GetValues("Access-Control-Allow-Origin").Should().Contain("*"))
                .Message(message => message.Content.Headers.GetValues("Content-Type").Should().Contain("application/json; charset=utf-8"))
                .Message(message => message.StatusCode.Should().Be(HttpStatusCode.OK));
        }

        [TestMethod]
        public void ItShouldBePossibleToCreateGetTestWithoutGiven()
        {
            When()
                .Get("https://reqres.in/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.OK));
        }
    }
}
