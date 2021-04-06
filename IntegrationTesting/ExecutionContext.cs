using System.Net.Http;

namespace IntegrationTesting
{
    internal class ExecutionContext : IExecutionContext
    {
        private readonly HttpResponseMessage _responseMessage;

        public ExecutionContext(HttpResponseMessage responseMessage)
        {
            _responseMessage = responseMessage;
        }

        public IResponseContext Then() => new ResponseContext(_responseMessage);
    }
}
