namespace AzureTestingUtility.TestConfigurations
{
    public class AzServiceBusTestConfig
    {
        public string EntityName { get; set; }
        public string TopicName { get; set; }
        public string[] PayloadPaths { get; set; }
    }
}
