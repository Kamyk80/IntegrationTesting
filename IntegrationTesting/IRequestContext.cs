using System;
using System.Net.Http;

namespace IntegrationTesting
{
    /// <summary>
    /// Request context, allowing to setup the request.
    /// </summary>
    public interface IRequestContext
    {
        /// <summary>
        /// Sets base address for a test case.
        /// </summary>
        public IRequestContext BaseAddress(string baseAddress);

        /// <summary>
        /// Sets timeout for a test case.
        /// </summary>
        public IRequestContext Timeout(TimeSpan timeout);

        /// <summary>
        /// Sets query string parameter for a test case.
        /// Query string parameters can be set either by URI or this method but not both.
        /// </summary>
        public IRequestContext Query(string name, string value);

        /// <summary>
        /// Sets header for a test case.
        /// Multi-value headers are supported.
        /// </summary>
        public IRequestContext Header(string name, params string[] values);

        /// <summary>
        /// Sets content for a test case.
        /// Supports anonymous objects and concrete model instances.
        /// </summary>
        public IRequestContext Content(object model);

        /// <summary>
        /// Sets raw content for a test case.
        /// </summary>
        public IRequestContext Content(string content);

        /// <summary>
        /// Exposes HttpClient instance for any operation which isn't implemented otherwise.
        /// Not intended to be used in test cases directly, intended to implement extension methods based on it instead.
        /// </summary>
        public IRequestContext Client(Action<HttpClient> action);

        /// <summary>
        /// Exposes HttpRequestMessage instance for any operation which isn't implemented otherwise.
        /// Not intended to be used in test cases directly, intended to implement extension methods based on it instead.
        /// </summary>
        public IRequestContext Message(Action<HttpRequestMessage> action);

        /// <summary>
        /// Starts When part of the test case.
        /// </summary>
        public IActionContext When();
    }
}
