﻿namespace IntegrationTesting
{
    public interface IActionContext
    {
        public IExecutionContext Get(string requestUri);
    }
}