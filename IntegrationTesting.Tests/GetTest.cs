using System;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using IntegrationTesting.Tests.Models;
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
                .ContentHeader("Content-Type", values => values.Should().Contain("application/json; charset=utf-8"));
        }

        [TestMethod]
        public void ItShouldBePossibleToCreateGetWithQueryTest()
        {
            Given()
                .BaseAddress("https://reqres.in")
                .Timeout(TimeSpan.FromSeconds(10))
                .Query("page", "1")
                .Header("Accept", "application/json")
            .When()
                .Get("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.OK));
        }

        [TestMethod]
        public void ItShouldBePossibleToCreateGetTestDeserializingToModel()
        {
            Given()
                .BaseAddress("https://reqres.in")
                .Timeout(TimeSpan.FromSeconds(10))
                .Header("Accept", "application/json")
            .When()
                .Get("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.OK))
                .JsonModel<UsersResponse>(model => model.Page.Should().Be(1));
        }

        [TestMethod]
        public void ItShouldBePossibleToCreateGetTestDeserializingToDynamic()
        {
            Given()
                .BaseAddress("https://reqres.in")
                .Timeout(TimeSpan.FromSeconds(10))
                .Header("Accept", "application/json")
            .When()
                .Get("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.OK))
                .JsonObject(json => ((int) json.page).Should().Be(1));
        }

        [TestMethod]
        public void ItShouldBePossibleToCreateGetTestUsingDirectObjects()
        {
            Given()
                .Client(client => client.BaseAddress = new Uri("https://reqres.in"))
                .Client(client => client.Timeout = TimeSpan.FromSeconds(10))
                .Message(message => message.Headers.Add("Accept", "application/json"))
            .When()
                .Send(HttpMethod.Get, "/api/users")
            .Then()
                .Message(message => message.StatusCode.Should().Be(HttpStatusCode.OK))
                .Message(message => message.Headers.GetValues("Access-Control-Allow-Origin").Should().Contain("*"))
                .Message(message => message.Content.Headers.GetValues("Content-Type").Should().Contain("application/json; charset=utf-8"))
                .Content(content => content.Should().Contain("\"page\":1"));
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
