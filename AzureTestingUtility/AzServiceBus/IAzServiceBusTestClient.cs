using AzureTestingUtility.AzServiceBus.UtilityComponents;
using AzureTestingUtility.TestConfigurations.Utils;

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
