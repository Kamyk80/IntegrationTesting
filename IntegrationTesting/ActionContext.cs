using System.Net.Http;

namespace IntegrationTesting
{
    internal class ActionContext : IActionContext
    {
        private readonly HttpClient _httpClient;

        public ActionContext()
        {
            _httpClient = new HttpClient();
        }

        public IExecutionContext Get(string requestUri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var responseMessage = _httpClient.Send(requestMessage);
            return new ExecutionContext(responseMessage);
        }
    }
}
