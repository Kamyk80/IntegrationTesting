namespace IntegrationTesting
{
    internal class ExecutionContext : IExecutionContext
    {
        public IResponseContext Then() => new ResponseContext();
    }
}
