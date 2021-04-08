using System;
using System.Net;
using System.Net.Http;

namespace IntegrationTesting
{
    public interface IResponseContext
    {
        public IResponseContext StatusCode(Action<HttpStatusCode> action);

        public IResponseContext JsonObject(Action<dynamic> action);

        public IResponseContext JsonArray(Action<dynamic> action);

        public IResponseContext Message(Action<HttpResponseMessage> action);
    }
}
