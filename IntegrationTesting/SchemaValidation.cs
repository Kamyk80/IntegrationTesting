using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

#pragma warning disable 618

namespace IntegrationTesting
{
    public static class SchemaValidation
    {
        public static IResponseContext ValidateJsonObjectSchema(this IResponseContext context, string schema, Action<bool> action) =>
            context.Content(content => action(JObject.Parse(content).IsValid(JsonSchema.Parse(schema))));

        public static IResponseContext ValidateJsonArraySchema(this IResponseContext context, string schema, Action<bool> action) =>
            context.Content(content => action(JArray.Parse(content).IsValid(JsonSchema.Parse(schema))));
    }
}
