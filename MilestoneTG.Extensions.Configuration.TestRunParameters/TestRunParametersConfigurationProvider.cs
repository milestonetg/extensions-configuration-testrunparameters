using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilestoneTG.Extensions.Configuration.TestRunParameters
{
    /// <summary>
    /// A <see cref="ConfigurationProvider"/> that is based on MSTest TestRunParameters.
    /// </summary>
    public class TestRunParametersConfigurationProvider : ConfigurationProvider
    {
        readonly TestContext testContext;

        /// <summary>
        /// Creates a new provider for a given MSTest test context.
        /// </summary>
        /// <param name="testContext">The test context to use.</param>
        public TestRunParametersConfigurationProvider(TestContext testContext)
        {
            this.testContext = testContext;
        }

        /// <summary>
        /// Loads the TestRunParameters.
        /// </summary>
        public override void Load()
        {
            if (testContext != null)
            {
                var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                var entries = testContext.Properties.Cast<KeyValuePair<string, object>>();

                foreach (var entry in entries)
                {
                    data[entry.Key] = (string)entry.Value;
                }

                Data = data;
            }

            base.Load();
        }
    }
}
