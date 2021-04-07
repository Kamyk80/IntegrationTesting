using System;
using System.Net.Http;

namespace IntegrationTesting
{
    public interface IRequestContext
    {
        IRequestContext BaseAddress(string baseAddress);

        IRequestContext Timeout(TimeSpan timeout);

        IRequestContext Header(string name, params string[] values);

        IRequestContext Content<TModel>(TModel model);

        IRequestContext Content(string content);

        IRequestContext Client(Action<HttpClient> action);

        IRequestContext Message(Action<HttpRequestMessage> action);

        IActionContext When();
    }
}
