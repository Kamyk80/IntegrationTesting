using System.Net.Http;

namespace IntegrationTesting
{
    public interface IActionContext
    {
        public IExecutionContext Get(string requestUri);

        public IExecutionContext Post(string requestUri);

        public IExecutionContext Put(string requestUri) => Send(HttpMethod.Put, requestUri);

        public IExecutionContext Patch(string requestUri) => Send(HttpMethod.Patch, requestUri);

        public IExecutionContext Delete(string requestUri) => Send(HttpMethod.Delete, requestUri);

        public IExecutionContext Send(HttpMethod method, string requestUri);
    }
}
