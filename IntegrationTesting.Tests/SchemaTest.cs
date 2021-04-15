using System;
using System.Net;
using FluentAssertions;
using IntegrationTesting.SchemaValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static IntegrationTesting.TestCase;

namespace IntegrationTesting.Tests
{
    [TestClass]
    public class SchemaTest
    {
        private const string ValidSchema =
            "{\"type\":\"object\",\"properties\":{\"id\":{'type\":\"string\",\"required':true},\"createdAt\":{\"type\":\"string\",\"required\":true}}}";

        private const string InvalidSchema =
            "{\"type\":\"object\",\"properties\":{\"id\":{'type\":\"string\",\"required':true},\"updatedAt\":{\"type\":\"string\",\"required\":true}}}";

        [TestMethod]
        public void ItShouldBePossibleToValidateSchemaSuccessfully()
        {
            Given()
                .BaseAddress("https://reqres.in")
                .Timeout(TimeSpan.FromSeconds(10))
                .Header("Accept", "application/json")
                .Content("{\"name\":\"morpheus\",\"job\":\"leader\"}")
            .When()
                .Post("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.Created))
                .ValidateJsonObjectSchema(ValidSchema, result => result.Should().BeTrue());
        }

        [TestMethod]
        public void ItShouldBePossibleToValidateSchemaUnsuccessfully()
        {
            Given()
                .BaseAddress("https://reqres.in")
                .Timeout(TimeSpan.FromSeconds(10))
                .Header("Accept", "application/json")
                .Content("{\"name\":\"morpheus\",\"job\":\"leader\"}")
            .When()
                .Post("/api/users")
            .Then()
                .StatusCode(code => code.Should().Be(HttpStatusCode.Created))
                .ValidateJsonObjectSchema(InvalidSchema, result => result.Should().BeFalse());
        }
    }
}
