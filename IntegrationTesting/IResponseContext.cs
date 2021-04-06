using System;
using System.Net;

namespace IntegrationTesting
{
    public interface IResponseContext
    {
        IResponseContext StatusCode(Action<HttpStatusCode> action);
    }
}
