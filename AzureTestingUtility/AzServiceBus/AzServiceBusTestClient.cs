using Azure.Messaging.ServiceBus;
using AzureTestingUtility.AzServiceBus.UtilityComponents;
using AzureTestingUtility.TestConfigurations.Utils;
using System.Text;

namespace AzureTestingUtility.AzServiceBus
{
    public class AzServiceBusTestClient : IAzServiceBusTestClient
    {
        private ServiceBusClient _serviceBusClient;
        private readonly Dictionary<int,ServiceBusClient> _serviceBusClients;

        public AzServiceBusTestClient(string[] serviceBusConnectionStrings)
        {
            // Assuming Connections Null below in the list.
            _serviceBusClients = new Dictionary<int,ServiceBusClient>();
            for (int conn = 0; conn < serviceBusConnectionStrings.Length; conn++) 
            {
                if (!conn.Equals("")) 
                {
                    _serviceBusClients.Add
                        (conn,
                        new ServiceBusClient(serviceBusConnectionStrings[conn]));
                }
            }
        }

        public async Task SendMessageToServiceBusTopicWithApplicationProperties
            (string topicName,
            string payload,
            AppProperties applicationProperties,
            SBEnvironments env) 
        {
            ServiceBusSender sender = _serviceBusClients[(int)env].CreateSender(topicName);
            try
            {
                topicName.PrintEntityName();
                env.ToString().PrintEnv();

                // Create a message
                var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(payload));

                // Add application properties
                foreach (AppProperty property in applicationProperties)
                {
                    message.ApplicationProperties.Add(property.Key, property.Value);
                }

                // Send the message to the topic
                await sender.SendMessageAsync(message);

                //Console.WriteLine($"Message sent: {payload}");
                payload.PrintPayload();
                "MessageSent".PrintSuccessResponse();
            }
            catch (Exception ex)
            {
                ex.Message.PrintFailureResponse();
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                await sender.CloseAsync();
            }
        }
    }
}
