# extensions-configuration-testrunparameters

[![Build Status](https://milestonetg.visualstudio.com/Milestone/_apis/build/status/milestonetg.extensions-configuration-testrunparameters?branchName=master)](https://milestonetg.visualstudio.com/Milestone/_build/latest?definitionId=42&branchName=master)

A [Microsoft.Extensions.Configuration](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration) provider for [MSTest](https://github.com/microsoft/testfx) TestRunParameters. 

## Example

```xml
<?xml version="1.0" encoding="utf-8" ?>
<RunSettings>
  <TestRunParameters>
    <!-- Parameters are provided as key/values in the configuration -->
    <Parameter name="Foo" value="Bar" />
    <!-- Parameter names can use ConfigurationPath.KeyDelimiter ":" -->
    <!-- to set nested configuration values -->
    <Parameter name="Nested:Foo" value="NestedBar" />
  </TestRunParameters>
</RunSettings>
```

```csharp
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Initialize
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            // Load configuration
            var configuration = new ConfigurationBuilder()
                // Add TestRunParameters as a configuration source
                //
                // The test run parameters are available through 
                // TestContext.Properties
                .AddTestRunParameters(testContext)
                .Build();

            // Prints "Bar"
            Console.WriteLine(configuration["Foo"]);

            // Get nested section
            var nestedConfiguration = configuration.GetSection("Nested");
            
            // Prints "NestedBar"
            Console.WriteLine(nestedConfiguration["Foo"]);
        }
    }
}
```
