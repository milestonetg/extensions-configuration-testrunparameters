using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MilestoneTG.Extensions.Configuration.TestRunParameters
{
    /// <summary>
    /// Represents MSTest TestRunParameters as an <see cref="IConfigurationSource"/>.
    /// </summary>
    public class TestRunParametersConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// The test context to pull run parameters from.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Builds the <see cref="TestRunParametersConfigurationProvider"/> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <returns>A <see cref="TestRunParametersConfigurationProvider"/></returns>
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new TestRunParametersConfigurationProvider(TestContext);
        }
    }
}
