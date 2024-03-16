using AzureTestingUtility.AzServiceBus.UtilityComponents;
using AzureTestingUtility.AzTestCases;
using AzureTestingUtility.TestConfigurations;

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
                .AzFunc_SetupAndRunTestAsync("ListenerL2Entity1Settings", 1);

            await _azFuncTestCase
                .AzFunc_SetupAndRunTestAsync("ListenerL2Entity1Settings", 2);


            await _azServiceBusTestCase
                .AzServiceBus_SetupAndRunTestAsync(
                "SubscriberL3Entity2Settings", 
                2,
                new ApplicationProperties()
                {
                    new KeyValuePair<string, string>("abc", "123"),
                    new KeyValuePair<string, string>("xyz", "456"),
                });

            await _azServiceBusTestCase
                .AzServiceBus_SetupAndRunTestAsync(
                "SubscriberL3Entity2Settings",
                1,
                new ApplicationProperties()
                {
                    new KeyValuePair<string, string>("abc", "123"),
                    new KeyValuePair<string, string>("xyz", "456"),
                });
        }
    }
}
