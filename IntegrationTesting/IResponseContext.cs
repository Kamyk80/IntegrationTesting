using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace IntegrationTesting
{
    public interface IResponseContext
    {
        public IResponseContext StatusCode(Action<HttpStatusCode> action);

        public IResponseContext Header(string name, Action<IEnumerable<string>> action);

        public IResponseContext ContentHeader(string name, Action<IEnumerable<string>> action);

        public IResponseContext JsonModel<TModel>(Action<TModel> action);

        public IResponseContext JsonObject(Action<dynamic> action);

        public IResponseContext JsonArray(Action<dynamic> action);

        public IResponseContext Message(Action<HttpResponseMessage> action);

        public IResponseContext Content(Action<string> action);
    }
}
