namespace IntegrationTesting
{
    internal class ActionContext : IActionContext
    {
        public IExecutionContext Get() => new ExecutionContext();
    }
}
