using System;
using System.Net.Http;

namespace IntegrationTesting
{
    internal class ActionContext : IActionContext
    {
        private readonly HttpClient _httpClient;
        private readonly HttpRequestMessage _requestMessage;

        public ActionContext(ITestConfiguration configuration)
        {
            _httpClient = new HttpClient(new LoggingHandler(new HttpClientHandler(), configuration.RequestLogging, configuration.ResponseLogging))
            {
                BaseAddress = configuration.BaseAddress
            };

            _requestMessage = new HttpRequestMessage();

            if (configuration.Timeout.HasValue)
            {
                _httpClient.Timeout = configuration.Timeout.Value;
            }
        }

        public ActionContext(HttpClient httpClient, HttpRequestMessage requestMessage)
        {
            _httpClient = httpClient;
            _requestMessage = requestMessage;
        }

        public IExecutionContext Get(string requestUri) => Send(HttpMethod.Get, requestUri);

        public IExecutionContext Post(string requestUri) => Send(HttpMethod.Post, requestUri);

        public IExecutionContext Put(string requestUri) => Send(HttpMethod.Put, requestUri);

        public IExecutionContext Patch(string requestUri) => Send(HttpMethod.Patch, requestUri);

        public IExecutionContext Delete(string requestUri) => Send(HttpMethod.Delete, requestUri);

        public IExecutionContext Send(HttpMethod method, string requestUri)
        {
            _requestMessage.Method = method;
            _requestMessage.RequestUri = new Uri(requestUri, UriKind.RelativeOrAbsolute);

            var responseMessage = _httpClient.Send(_requestMessage);

            return new ExecutionContext(responseMessage);
        }
    }
}
