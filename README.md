# IntegrationTesting

This is a simple REST services integration testing suite, built with [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0), based on BDD approach, inspired by [REST Assured](https://rest-assured.io/) (but not trying to be its full .NET implementation).

Currently supports JSON based services only.

## Installation

Install with [NuGet Package Manager](https://www.nuget.org/packages/Kamyko.IntegrationTesting/):

```
PM> Install-Package Kamyko.IntegrationTesting
```

## Base assumptions

- Simple and clean code, easily understandable by anyone willing to extend it.
- Easily extendable, even without modifying its source code (by extension methods).
- Integration with [Json.NET](https://www.newtonsoft.com/json) for JSON serialization and deserialization.
- Not providing its own assertions and being able to use any assertion framework.

## Example test case

```csharp
Given()
    .BaseAddress("https://reqres.in")
    .Header("Accept", "application/json")
    .Content(new {name = "morpheus", job = "leader"})
.When()
    .Post("/api/users")
.Then()
    .StatusCode(code => code.Should().Be(HttpStatusCode.Created));
```

The above example uses [FluentAssertions](https://fluentassertions.com/).

## Test case structure

The test case consists of 3 parts:

- after `Given()` there is test case setup - configures `HttpClient` and `HttpRequestMessage` used for the test,
- after `When()` there is actual HTTP call - either GET, POST, PUT, PATCH or DELETE (other methods are also supported),
- after `Then()` you can put `HttpResponseMessage` and content validation, using your favourite assertion methods.

## How to use

For best experience, declare using `TestCase` class directly by the following statement:

```
using static IntegrationTesting.TestCase;
```

### Configuration

```csharp
Configuration.BaseAddress = new Uri("https://reqres.in");
```

Sets base address for all test cases.
\
It can be also set for each test case individually.

```csharp
Configuration.Timeout = TimeSpan.FromSeconds(10);
```

Sets timeout for all test cases.
\
It can be also set for each test case individually.

```csharp
Configuration.RequestLogging = true;
```

Enables request logging.

```csharp
Configuration.ResponseLogging = true;
```

Enables response logging.

Logs are written to console. Both Visual Studio and ReSharper test runners show console logs for each test.

Configuration is global for all test cases and is intended to be placed in your global tests initialization.

### Given clause

```csharp
.BaseAddress("https://reqres.in")
```

Sets base address for a test case.

```csharp
.Timeout(TimeSpan.FromSeconds(10))
```

Sets timeout for a test case.

```csharp
.Query("page", "1")
```

Sets query string parameter for a test case.
\
Query string parameters can be set either by URI or by this method, but not both.

```csharp
.Header("Accept", "application/json")
```

Sets header for a test case.
\
Multi-value headers are supported.

```csharp
.Content(new {name = "morpheus", job = "leader"})
```

Sets content for a test case.
\
Supports anonymous objects and concrete model instances.

```csharp
.Content("{\"name\":\"morpheus\",\"job\":\"leader\"}")
```

Sets raw content for a test case.

```csharp
.Client(client => client.BaseAddress = new Uri("https://reqres.in"))
```

Exposes HttpClient instance for any operation which isn't implemented otherwise.
\
Not intended to be used in test cases directly, intended to implement extension methods based on it instead.

```csharp
.Message(message => message.Headers.Add("Accept", "application/json"))
```

Exposes HttpRequestMessage instance for any operation which isn't implemented otherwise.
\
Not intended to be used in test cases directly, intended to implement extension methods based on it instead.

Given clause can be omitted and simple test cases can start directly with When.

### When clause

```csharp
.Get("/api/users")
```

Makes GET request.

```csharp
.Post("/api/users")
```

Makes POST request.

```csharp
.Put("/api/users/2")
```

Makes PUT request.

```csharp
.Patch("/api/users/2")
```

Makes PATCH request.

```csharp
.Delete("/api/users/2")
```

Makes DELETE request.

```csharp
.Send(HttpMethod.Head, "/api/users")
```

Makes any request.

URI can be either relative or absolute (when base address is not used).

### Then clause

This suite doesn't implement any assertions itself. It allows you to use any test framework and assertions instead. Examples below use [FluentAssertions](https://fluentassertions.com/).

```csharp
.StatusCode(code => code.Should().Be(HttpStatusCode.OK))
```

Inspects status code.

```csharp
.Header("Access-Control-Allow-Origin", values => values.Should().Contain("*"))
```

Inspects header value.
\
Multi-value headers are supported.

```csharp
.ContentHeader("Content-Type", values => values.Should().Contain("application/json; charset=utf-8"))
```

Inspects content header value.
\
HttpClient stores response headers separately. 
\
Multi-value headers are supported.

```csharp
.Content(content => content.Should().Contain("\"page\":1"))
```

Inspects raw content.

```csharp
.JsonModel<UsersResponse>(model => model.Page.Should().Be(1))
```

Inspects content deserialized to concrete model class.

```csharp
.JsonObject(json => ((int) json.page).Should().Be(1))
```

Inspects content deserialized to JSON object as dynamic type.

```csharp
.JsonArray(json => ((int) json[0].page).Should().Be(1))
```

Inspects content deserialized to JSON array as dynamic type.

```csharp
.Message(message => message.StatusCode.Should().Be(HttpStatusCode.OK))
```

Inspects HttpResponseMessage for any operation which isn't implemented otherwise.
\
Not intended to be used in test cases directly, intended to implement extension methods based on it instead.

Schema validation described below is implemented as extension methods, so you can use it as an example how to implement your own extensions.

```csharp
.ValidateJsonObjectSchema(SchemaString, result => result.Should().BeTrue());
```

Validates JSON object schema and exposes validation result for inspection.

```csharp
.ValidateJsonArraySchema(SchemaString, result => result.Should().BeTrue());
```

Validates JSON array schema and exposes validation result for inspection.

## More examples

For more examples please check test project. Tests are written as real use cases, testing real REST service [ReqRes](https://reqres.in/).
