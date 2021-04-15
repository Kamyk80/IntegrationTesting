namespace IntegrationTesting
{
    /// <summary>
    /// Static class with entry points to everything.
    /// </summary>
    public static class TestCase
    {
        /// <summary>
        /// Global test case configuration.
        /// </summary>
        public static ITestConfiguration Configuration { get; } = new TestConfiguration();

        /// <summary>
        /// Starts test case chain.
        /// </summary>
        public static IRequestContext Given() => new RequestContext(Configuration);

        /// <summary>
        /// Starts test case chain.
        /// Given() can be omitted.
        /// </summary>
        public static IActionContext When() => new ActionContext(Configuration);
    }
}
