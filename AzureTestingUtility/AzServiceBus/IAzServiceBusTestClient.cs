using AzureTestingUtility.AzServiceBus.UtilityComponents;
using AzureTestingUtility.TestConfigurations;

namespace AzureTestingUtility.AzServiceBus
{
    public interface IAzServiceBusTestClient
    {
        public Task SendMessageToServiceBusTopicWithApplicationProperties(
            string topic,
            string payload,
            AppProperties applicationProperties,
            SBEnvironments env);
    }
}
