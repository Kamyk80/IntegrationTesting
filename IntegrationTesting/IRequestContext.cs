using System;
using System.Net.Http;

namespace IntegrationTesting
{
    public interface IRequestContext
    {
        public IRequestContext BaseAddress(string baseAddress);

        public IRequestContext Timeout(TimeSpan timeout);

        public IRequestContext Header(string name, params string[] values);

        public IRequestContext Content(object model);

        public IRequestContext Content(string content);

        public IRequestContext Client(Action<HttpClient> action);

        public IRequestContext Message(Action<HttpRequestMessage> action);

        public IActionContext When();
    }
}
