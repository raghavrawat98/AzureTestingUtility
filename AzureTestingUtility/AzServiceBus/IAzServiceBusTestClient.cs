using AzureTestingUtility.AzServiceBus.UtilityComponents;

namespace AzureTestingUtility.AzServiceBus
{
    public interface IAzServiceBusTestClient
    {
        public Task SendMessageToServiceBusTopicWithApplicationProperties(
            string topic,
            string payload,
            ApplicationProperties applicationProperties);
    }
}
