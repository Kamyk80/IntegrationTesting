using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace IntegrationTesting
{
    /// <summary>
    /// Response context, allowing to inspect the response.
    /// </summary>
    public interface IResponseContext
    {
        /// <summary>
        /// Inspects status code.
        /// </summary>
        public IResponseContext StatusCode(Action<HttpStatusCode> action);

        /// <summary>
        /// Inspects header value.
        /// Multi-value headers are supported.
        /// </summary>
        public IResponseContext Header(string name, Action<IEnumerable<string>> action);

        /// <summary>
        /// Inspects content header value.
        /// HttpClient stores response headers separately.
        /// Multi-value headers are supported.
        /// </summary>
        public IResponseContext ContentHeader(string name, Action<IEnumerable<string>> action);

        /// <summary>
        /// Inspects raw content.
        /// </summary>
        public IResponseContext Content(Action<string> action);

        /// <summary>
        /// Inspects content deserialized to concrete model class.
        /// </summary>
        public IResponseContext JsonModel<TModel>(Action<TModel> action);

        /// <summary>
        /// Inspects content deserialized to JSON object as dynamic type.
        /// </summary>
        public IResponseContext JsonObject(Action<dynamic> action);

        /// <summary>
        /// Inspects content deserialized to JSON array as dynamic type.
        /// </summary>
        public IResponseContext JsonArray(Action<dynamic> action);

        /// <summary>
        /// Inspects HttpResponseMessage for any operation which isn't implemented otherwise.
        /// Not intended to be used in test cases directly, intended to implement extension methods based on it instead.
        /// </summary>
        public IResponseContext Message(Action<HttpResponseMessage> action);
    }
}
