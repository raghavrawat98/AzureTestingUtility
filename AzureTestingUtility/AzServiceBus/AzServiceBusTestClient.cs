using Azure.Messaging.ServiceBus;
using AzureTestingUtility.AzServiceBus.UtilityComponents;
using System.Text;

namespace AzureTestingUtility.AzServiceBus
{
    public class AzServiceBusTestClient : IAzServiceBusTestClient
    {
        private ServiceBusClient _serviceBusClient;

        public AzServiceBusTestClient(string serviceBusConnectionString)
        {
            _serviceBusClient = new ServiceBusClient(serviceBusConnectionString);
        }

        public async Task SendMessageToServiceBusTopicWithApplicationProperties
            (string topicName,
            string payload,
            ApplicationProperties applicationProperties) 
        {
            ServiceBusSender sender = _serviceBusClient.CreateSender(topicName);

            try
            {
                // Create a message
                var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(payload));

                // Add application properties
                foreach (KeyValuePair<string,string> property in applicationProperties)
                {
                    message.ApplicationProperties.Add(property.Key, property.Value);

                }

                // Send the message to the topic
                await sender.SendMessageAsync(message);

                Console.WriteLine($"Message sent: {payload}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                await sender.CloseAsync();
            }
        }
    }
}
