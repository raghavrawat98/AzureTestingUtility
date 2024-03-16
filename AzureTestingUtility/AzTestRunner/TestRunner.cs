using AzureTestingUtility.AzServiceBus.UtilityComponents;
using AzureTestingUtility.AzTestCases;
using AzureTestingUtility.TestConfigurations;
using AzureTestingUtility.TestConfigurations.Utils;

namespace AzureTestingUtility.AzTestRunner
{
    public class TestRunner
    {
        private AzFuncTestCase _azFuncTestCase;
        private AzServiceBusTestCase _azServiceBusTestCase;
        public TestRunner(TestConfigs testConfigs) 
        {
            _azFuncTestCase = new AzFuncTestCase(testConfigs);
            _azServiceBusTestCase = new AzServiceBusTestCase(testConfigs);
        }
        public async Task ExecuteAsync() 
        {
            await _azFuncTestCase
                .AzFunc_SetupAndRunTestAsync
                ("ListenerL2Entity1Settings", 1,
                AzFuncEnvironments.Dev);

            await _azFuncTestCase
                .AzFunc_SetupAndRunTestAsync
                ("ListenerL2Entity2Settings", 2, 
                AzFuncEnvironments.Local);

            await _azServiceBusTestCase
                .AzServiceBus_SetupAndRunTestAsync(
                "SubscriberL3Entity2Settings",
                1,
                new AppProperties()
                {
                    new AppProperty("abc", "123"),
                    new AppProperty("xyz", "456"),
                },
                SBEnvironments.Dev);

            await _azServiceBusTestCase
                .AzServiceBus_SetupAndRunTestAsync(
                "SubscriberL3Entity1Settings",
                1,
                new AppProperties()
                {
                    new AppProperty("abc", "123"),
                    new AppProperty("xyz", "456"),
                },
                SBEnvironments.Test);
        }
    }
}
