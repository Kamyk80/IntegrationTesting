namespace IntegrationTesting
{
    internal class TestConfig : ITestConfig
    {
        public bool RequestLogging { get; set; }

        public bool ResponseLogging { get; set; }
    }
}
