using System.Net.Http;

namespace IntegrationTesting
{
    public interface IActionContext
    {
        public IExecutionContext Get(string requestUri);

        public IExecutionContext Post(string requestUri);

        public IExecutionContext Send(HttpMethod method, string requestUri);
    }
}
