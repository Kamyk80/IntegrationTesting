using System;
using System.Net;

namespace IntegrationTesting
{
    public interface IResponseContext
    {
        public IResponseContext StatusCode(Action<HttpStatusCode> action);
    }
}
