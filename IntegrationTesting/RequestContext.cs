using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace IntegrationTesting
{
    internal class RequestContext : IRequestContext
    {
        private readonly HttpClient _httpClient;
        private readonly HttpRequestMessage _requestMessage;

        public RequestContext()
        {
            _httpClient = new HttpClient(new LoggingHandler(new HttpClientHandler()));
            _requestMessage = new HttpRequestMessage();
        }

        public IRequestContext BaseAddress(string baseAddress)
        {
            _httpClient.BaseAddress = new Uri(baseAddress);

            return this;
        }

        public IRequestContext Timeout(TimeSpan timeout)
        {
            _httpClient.Timeout = timeout;

            return this;
        }

        public IRequestContext Header(string name, params string[] values)
        {
            _requestMessage.Headers.Add(name, values);

            return this;
        }

        public IRequestContext Content<TModel>(TModel model)
        {
            var content = JsonConvert.SerializeObject(model);

            return Content(content);
        }

        public IRequestContext Content(string content)
        {
            _requestMessage.Content = new StringContent(content);

            return this;
        }

        public IRequestContext Client(Action<HttpClient> action)
        {
            action(_httpClient);

            return this;
        }

        public IRequestContext Message(Action<HttpRequestMessage> action)
        {
            action(_requestMessage);

            return this;
        }

        public IActionContext When() => new ActionContext(_httpClient, _requestMessage);
    }
}
