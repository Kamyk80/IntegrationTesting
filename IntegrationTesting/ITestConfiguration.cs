using System;

namespace IntegrationTesting
{
    /// <summary>
    /// Test case configuration.
    /// </summary>
    public interface ITestConfiguration
    {
        /// <summary>
        /// Sets base address for all test cases.
        /// It can be also set for each test case individually.
        /// </summary>
        public Uri BaseAddress { get; set; }

        /// <summary>
        /// Sets timeout for all test cases.
        /// It can be also set for each test case individually.
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Enables request logging.
        /// </summary>
        public bool RequestLogging { get; set; }

        /// <summary>
        /// Enables response logging.
        /// </summary>
        public bool ResponseLogging { get; set; }
    }
}
