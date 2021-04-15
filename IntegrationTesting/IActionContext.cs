using System.Net.Http;

namespace IntegrationTesting
{
    /// <summary>
    /// Action context, allowing to make action.
    /// </summary>
    public interface IActionContext
    {
        /// <summary>
        /// Makes GET request.
        /// URI can be either relative or absolute (when base address is not used).
        /// </summary>
        public IExecutionContext Get(string requestUri);

        /// <summary>
        /// Makes POST request.
        /// URI can be either relative or absolute (when base address is not used).
        /// </summary>
        public IExecutionContext Post(string requestUri);

        /// <summary>
        /// Makes PUT request.
        /// URI can be either relative or absolute (when base address is not used).
        /// </summary>
        public IExecutionContext Put(string requestUri);

        /// <summary>
        /// Makes PATCH request.
        /// URI can be either relative or absolute (when base address is not used).
        /// </summary>
        public IExecutionContext Patch(string requestUri);

        /// <summary>
        /// Makes DELETE request.
        /// URI can be either relative or absolute (when base address is not used).
        /// </summary>
        public IExecutionContext Delete(string requestUri);

        /// <summary>
        /// Makes any request.
        /// URI can be either relative or absolute (when base address is not used).
        /// </summary>
        public IExecutionContext Send(HttpMethod method, string requestUri);
    }
}
