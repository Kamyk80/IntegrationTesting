using System;
using System.Net;
using System.Net.Http;

namespace IntegrationTesting
{
    internal class ResponseContext : IResponseContext
    {
        private readonly HttpResponseMessage _responseMessage;

        public ResponseContext(HttpResponseMessage responseMessage)
        {
            _responseMessage = responseMessage;
        }

        public IResponseContext StatusCode(Action<HttpStatusCode> action)
        {
            action(_responseMessage.StatusCode);

            return this;
        }
    }
}
