namespace IntegrationTesting
{
    public static class TestCase
    {
        public static ITestConfig Config { get; } = new TestConfig();

        public static IRequestContext Given() => new RequestContext(Config);

        public static IActionContext When() => new ActionContext(Config);
    }
}
