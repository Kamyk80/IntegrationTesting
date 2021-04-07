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
            Config.RequestLogging = true;
            Config.ResponseLogging = true;
        }
    }
}
