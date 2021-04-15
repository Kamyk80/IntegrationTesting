using System;

namespace IntegrationTesting
{
    internal class TestConfiguration : ITestConfiguration
    {
        public Uri BaseAddress { get; set; }

        public TimeSpan? Timeout { get; set; }

        public bool RequestLogging { get; set; }

        public bool ResponseLogging { get; set; }
    }
}
