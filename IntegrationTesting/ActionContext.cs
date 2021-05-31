using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace IntegrationTesting
{
    internal class ActionContext : IActionContext
    {
        private readonly HttpClient _httpClient;
        private readonly HttpRequestMessage _requestMessage;
        private readonly IList<(string, string)> _queryParams;

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

            _queryParams = new List<(string, string)>();
        }

        public ActionContext(HttpClient httpClient, HttpRequestMessage requestMessage, IList<(string, string)> queryParams)
        {
            _httpClient = httpClient;
            _requestMessage = requestMessage;
            _queryParams = queryParams;
        }

        public IExecutionContext Get(string requestUri) => Send(HttpMethod.Get, requestUri);

        public IExecutionContext Post(string requestUri) => Send(HttpMethod.Post, requestUri);

        public IExecutionContext Put(string requestUri) => Send(HttpMethod.Put, requestUri);

        public IExecutionContext Patch(string requestUri) => Send(HttpMethod.Patch, requestUri);

        public IExecutionContext Delete(string requestUri) => Send(HttpMethod.Delete, requestUri);

        public IExecutionContext Send(HttpMethod method, string requestUri)
        {
            _requestMessage.Method = method;
            _requestMessage.RequestUri = new Uri(AddQueryString(requestUri), UriKind.RelativeOrAbsolute);

            var responseMessage = _httpClient.Send(_requestMessage);

            return new ExecutionContext(responseMessage);
        }

        private string AddQueryString(string requestUri)
        {
            if (_queryParams.Any())
            {
                if (requestUri.Contains('?'))
                {
                    throw new InvalidOperationException("Query() cannot be used when URI contains query string already.");
                }

                // This trick creates instance of internal HttpQSCollection class.
                var queryParams = HttpUtility.ParseQueryString(string.Empty);

                foreach (var (name, value) in _queryParams)
                {
                    queryParams.Add(name, value);
                }

                requestUri += $"?{queryParams}";
            }

            return requestUri;
        }
    }
}
