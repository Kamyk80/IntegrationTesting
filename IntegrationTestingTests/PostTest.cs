using System;
using System.Net;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using static IntegrationTesting.TestCase;

namespace IntegrationTestingTests
{
    [TestClass]
    public class PostTest
    {
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
                .Content(new Model {Name = "morpheus", Job = "leader"})
            .When()
                .Post("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.Created));
        }

        private class Model
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("job")]
            public string Job { get; set; }
        }
    }
}
