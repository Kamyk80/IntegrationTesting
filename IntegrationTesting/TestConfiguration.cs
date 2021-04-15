namespace IntegrationTesting
{
    internal class TestConfiguration : ITestConfiguration
    {
        public bool RequestLogging { get; set; }

        public bool ResponseLogging { get; set; }
    }
}
