using System;
using System.Net.Http;

namespace IntegrationTesting
{
    internal class ActionContext : IActionContext
    {
        private readonly HttpClient _httpClient;
        private readonly HttpRequestMessage _requestMessage;

        public ActionContext()
        {
            _httpClient = new HttpClient();
            _requestMessage = new HttpRequestMessage();
        }

        public ActionContext(HttpClient httpClient, HttpRequestMessage requestMessage)
        {
            _httpClient = httpClient;
            _requestMessage = requestMessage;
        }

        public IExecutionContext Get(string requestUri)
        {
            _requestMessage.Method = HttpMethod.Get;
            _requestMessage.RequestUri = new Uri(requestUri, UriKind.RelativeOrAbsolute);

            var responseMessage = _httpClient.Send(_requestMessage);

            return new ExecutionContext(responseMessage);
        }
    }
}
