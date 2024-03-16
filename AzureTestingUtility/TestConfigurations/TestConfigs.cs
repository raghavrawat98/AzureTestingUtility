namespace AzureTestingUtility.TestConfigurations
{
    public class TestConfigs
    {
        public string[] ServiceBusConnectionStrings { get; set; }
        public string? TestPayloadsFolderPath { get; set; }
        public List<AzFunctionTestConfig>? AzFunctionTestConfig { get; set; }
        public List<AzServiceBusTestConfig>? AzServiceBusTestConfig { get; set; }
    }
}
