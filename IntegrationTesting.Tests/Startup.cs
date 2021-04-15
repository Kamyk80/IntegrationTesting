using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static IntegrationTesting.TestCase;

namespace IntegrationTesting.Tests
{
    [TestClass]
    public class Startup
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Configuration.BaseAddress = new Uri("https://reqres.in");
            Configuration.Timeout = TimeSpan.FromSeconds(10);

            Configuration.RequestLogging = true;
            Configuration.ResponseLogging = true;
        }
    }
}
