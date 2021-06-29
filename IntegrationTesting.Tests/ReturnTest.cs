using System;
using System.Net;
using FluentAssertions;
using IntegrationTesting.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static IntegrationTesting.TestCase;

namespace IntegrationTesting.Tests
{
    [TestClass]
    public class ReturnTest
    {
        [TestMethod]
        public void ItShouldBePossibleToReturnRawContent()
        {
            var content = Given()
                .BaseAddress("https://reqres.in")
                .Timeout(TimeSpan.FromSeconds(10))
                .Header("Accept", "application/json")
                .Content(new {name = "morpheus", job = "leader"})
            .When()
                .Post("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.Created))
                .ReturnContent();

            content.Should().NotBeNull();
        }

        [TestMethod]
        public void ItShouldBePossibleToReturnDeserializedModel()
        {
            var model = Given()
                .BaseAddress("https://reqres.in")
                .Timeout(TimeSpan.FromSeconds(10))
                .Header("Accept", "application/json")
                .Content(new {name = "morpheus", job = "leader"})
            .When()
                .Post("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.Created))
                .ReturnJsonModel<CreateResponse>();

            model.Id.Should().BePositive();
        }

        [TestMethod]
        public void ItShouldBePossibleToReturnValueFromDynamic()
        {
            var id = Given()
                .BaseAddress("https://reqres.in")
                .Header("Accept", "application/json")
                .Content(new {name = "morpheus", job = "leader"})
            .When()
                .Post("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.Created))
                .ReturnFromJsonObject<int>(json => json.id);

            id.Should().BePositive();
        }
    }
}
