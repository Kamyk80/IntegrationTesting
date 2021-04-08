namespace IntegrationTesting
{
    public interface ITestConfig
    {
        public bool RequestLogging { get; set; }

        public bool ResponseLogging { get; set; }
    }
}
