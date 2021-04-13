using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
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
            var values = _responseMessage.Headers.GetValues(name);

            action(values);

            return this;
        }

        public IResponseContext ContentHeader(string name, Action<IEnumerable<string>> action)
        {
            var values = _responseMessage.Content.Headers.GetValues(name);

            action(values);

            return this;
        }

        public IResponseContext JsonModel<TModel>(Action<TModel> action)
        {
            var jsonModel = JsonConvert.DeserializeObject<TModel>(_responseContent);

            action(jsonModel);

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
            var jsonArray = JArray.Parse(_responseContent);

            action(jsonArray);

            return this;
        }

        public IResponseContext Message(Action<HttpResponseMessage> action)
        {
            action(_responseMessage);

            return this;
        }

        public IResponseContext Content(Action<string> action)
        {
            action(_responseContent);

            return this;
        }
    }
}
