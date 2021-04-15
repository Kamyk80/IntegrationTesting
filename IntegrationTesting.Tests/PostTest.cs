using System;
using System.Net;
using FluentAssertions;
using IntegrationTesting.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static IntegrationTesting.TestCase;

namespace IntegrationTesting.Tests
{
    [TestClass]
    public class PostTest
    {
        [TestMethod]
        public void ItShouldBePossibleToCreatePostObjectTest()
        {
            Given()
                .BaseAddress("https://reqres.in")
                .Timeout(TimeSpan.FromSeconds(10))
                .Header("Accept", "application/json")
                .Content(new {name = "morpheus", job = "leader"})
            .When()
                .Post("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.Created));
        }

        [TestMethod]
        public void ItShouldBePossibleToCreatePostModelTest()
        {
            Given()
                .BaseAddress("https://reqres.in")
                .Timeout(TimeSpan.FromSeconds(10))
                .Header("Accept", "application/json")
                .Content(new UserRequest {Name = "morpheus", Job = "leader"})
            .When()
                .Post("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.Created));
        }

        [TestMethod]
        public void ItShouldBePossibleToCreatePostStringTest()
        {
            Given()
                .BaseAddress("https://reqres.in")
                .Timeout(TimeSpan.FromSeconds(10))
                .Header("Accept", "application/json")
                .Content("{\"name\":\"morpheus\",\"job\":\"leader\"}")
            .When()
                .Post("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.Created));
        }
    }
}
