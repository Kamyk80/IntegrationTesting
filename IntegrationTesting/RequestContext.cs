namespace IntegrationTesting
{
    internal class RequestContext : IRequestContext
    {
        public IActionContext When() => new ActionContext();
    }
}
