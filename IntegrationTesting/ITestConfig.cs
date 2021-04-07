namespace IntegrationTesting
{
    public interface ITestConfig
    {
        bool RequestLogging { get; set; }

        bool ResponseLogging { get; set; }
    }
}
