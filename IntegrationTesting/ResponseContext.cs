using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace IntegrationTesting
{
    internal class ResponseContext : IResponseContext
    {
        private readonly HttpResponseMessage _responseMessage;
        private readonly string _responseContent;

        public ResponseContext(HttpResponseMessage responseMessage)
        {
            _responseMessage = responseMessage;
            _responseContent = _responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public IResponseContext StatusCode(Action<HttpStatusCode> action)
        {
            action(_responseMessage.StatusCode);

            return this;
        }

        public IResponseContext Header(string name, Action<IEnumerable<string>> action)
        {
            action(_responseMessage.Headers.GetValues(name));

            return this;
        }

        public IResponseContext ContentHeader(string name, Action<IEnumerable<string>> action)
        {
            action(_responseMessage.Content.Headers.GetValues(name));

            return this;
        }

        public IResponseContext JsonObject(Action<dynamic> action)
        {
            var jsonObject = JObject.Parse(_responseContent);

            action(jsonObject);

            return this;
        }

        public IResponseContext JsonArray(Action<dynamic> action)
        {
            var jsonObject = JArray.Parse(_responseContent);

            action(jsonObject);

            return this;
        }

        public IResponseContext Message(Action<HttpResponseMessage> action)
        {
            action(_responseMessage);

            return this;
        }
    }
}
