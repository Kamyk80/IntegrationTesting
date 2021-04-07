using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationTesting
{
    internal class LoggingHandler : DelegatingHandler
    {
        public LoggingHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {
        }

        protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LogRequest(request);

            var response = base.Send(request, cancellationToken);

            LogResponse(response);

            return response;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LogRequest(request);

            var response = await base.SendAsync(request, cancellationToken);

            LogResponse(response);

            return response;
        }

        private static void LogRequest(HttpRequestMessage request)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Request:");

            sb.Append("Method: ");
            sb.AppendLine(request.Method.ToString());

            sb.Append("Uri: ");
            sb.AppendLine(request.RequestUri?.ToString() ?? "<null>");

            if (request.Headers.Any())
            {
                sb.AppendLine("Headers:");
                foreach (var (name, values) in request.Headers)
                {
                    sb.AppendLine($"  {name}: {string.Join(", ", values)}");
                }
            }
            else
            {
                sb.AppendLine("Headers: <none>");
            }

            if (request.Content != null)
            {
                var content = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (!string.IsNullOrEmpty(content))
                {
                    sb.AppendLine("Content:");
                    sb.AppendLine(content);
                }
                else
                {
                    sb.AppendLine("Content: <empty>");
                }
            }
            else
            {
                sb.AppendLine("Content: <null>");
            }

            Console.WriteLine(sb.ToString());
        }

        private static void LogResponse(HttpResponseMessage response)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Response:");

            sb.Append("StatusCode: ");
            sb.AppendLine(((int) response.StatusCode).ToString());

            sb.Append("ReasonPhrase: ");
            sb.AppendLine(response.ReasonPhrase ?? "<null>");

            if (response.Headers.Any())
            {
                sb.AppendLine("Headers:");
                foreach (var (name, values) in response.Headers)
                {
                    sb.AppendLine($"  {name}: {string.Join(", ", values)}");
                }
            }
            else
            {
                sb.AppendLine("Headers: <none>");
            }

            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (!string.IsNullOrEmpty(content))
            {
                sb.AppendLine("Content:");
                sb.AppendLine(content);
            }
            else
            {
                sb.AppendLine("Content: <empty>");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
