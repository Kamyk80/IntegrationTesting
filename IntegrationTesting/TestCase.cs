namespace IntegrationTesting
{
    public static class TestCase
    {
        public static IRequestContext Given() => new RequestContext();

        public static IActionContext When() => new ActionContext();
    }
}
