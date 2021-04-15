namespace IntegrationTesting
{
    /// <summary>
    /// Execution context, action already executed.
    /// </summary>
    public interface IExecutionContext
    {
        /// <summary>
        /// Starts Then part of the test case.
        /// </summary>
        public IResponseContext Then();
    }
}
