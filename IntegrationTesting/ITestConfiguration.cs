namespace IntegrationTesting
{
    /// <summary>
    /// Test case configuration.
    /// </summary>
    public interface ITestConfiguration
    {
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
