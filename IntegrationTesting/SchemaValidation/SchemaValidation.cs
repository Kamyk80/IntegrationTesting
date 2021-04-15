using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

// Uses obsolete schema validation built into Json.NET.
// If you prefer using Json.NET Schema instead, you can implement it yourself in the same way.
#pragma warning disable 618

namespace IntegrationTesting.SchemaValidation
{
    public static class SchemaValidation
    {
        /// <summary>
        /// Validates JSON object schema and exposes validation result for inspection.
        /// </summary>
        public static IResponseContext ValidateJsonObjectSchema(this IResponseContext context, string schema, Action<bool> action) =>
            context.Content(content => action(JObject.Parse(content).IsValid(JsonSchema.Parse(schema))));

        /// <summary>
        /// Validates JSON array schema and exposes validation result for inspection.
        /// </summary>
        public static IResponseContext ValidateJsonArraySchema(this IResponseContext context, string schema, Action<bool> action) =>
            context.Content(content => action(JArray.Parse(content).IsValid(JsonSchema.Parse(schema))));
    }
}
