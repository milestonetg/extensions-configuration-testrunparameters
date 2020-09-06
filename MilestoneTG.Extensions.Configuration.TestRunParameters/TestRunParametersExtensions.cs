using Microsoft.VisualStudio.TestTools.UnitTesting;
using MilestoneTG.Extensions.Configuration.TestRunParameters;
using System;

namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// Extension methods for registering a <see cref="TestRunParametersConfigurationProvider"/> with <see cref="IConfigurationBuilder"/>.
    /// </summary>
    public static class TestRunParametersExtensions
    {
        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from MSTest TestRunParameters.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="testContext">The test context to read test run parameters from.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddTestRunParameters(
            this IConfigurationBuilder builder,
            TestContext testContext)
        {
            builder.Add(new TestRunParametersConfigurationSource { TestContext = testContext });
            return builder;
        }

        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from MSTest TestRunParameters.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="configureSource">Configures the source.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddTestRunParameters(this IConfigurationBuilder builder, Action<TestRunParametersConfigurationSource> configureSource)
            => builder.Add(configureSource);
    }
}
