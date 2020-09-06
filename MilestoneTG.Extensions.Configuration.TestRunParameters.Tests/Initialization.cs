using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MilestoneTG.Extensions.Configuration.TestRunParameters.Tests
{
    [TestClass]
    public static class Initialization
    {
        public static IConfiguration Configuration { get; private set; }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            Configuration = new ConfigurationBuilder()
                .AddTestRunParameters(testContext)
                .Build();
        }
    }
}
