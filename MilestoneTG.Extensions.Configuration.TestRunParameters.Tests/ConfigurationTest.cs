using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MilestoneTG.Extensions.Configuration.TestRunParameters.Tests
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        public void Config_Loads_From_Runsettings()
        {
            IConfiguration config = Initialization.Configuration;

            Assert.AreEqual("Bar", config["Foo"]);
            Assert.AreEqual("NestedBar", config["Nested:Foo"]);
            Assert.AreEqual("NestedBar", config.GetSection("Nested")["Foo"]);
        }
    }
}
