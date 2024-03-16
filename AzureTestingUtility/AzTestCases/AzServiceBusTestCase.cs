using AzureTestingUtility.AzServiceBus;
using AzureTestingUtility.AzServiceBus.UtilityComponents;
using AzureTestingUtility.FileHelperService.PayloadFileHelper;
using AzureTestingUtility.TestConfigurations;

namespace AzureTestingUtility.AzTestCases
{
    public class AzServiceBusTestCase
    {
        private IAzServiceBusTestClient _azServiceBusTestClient;
        private List<AzServiceBusTestConfig> _serviceBusTestConfig;
        private PayloadFileHelper _payloadFileHelper;

        public AzServiceBusTestCase(
            TestConfigs testConfigs
            )
        {
            _payloadFileHelper = new PayloadFileHelper(testConfigs);
            _azServiceBusTestClient = new AzServiceBusTestClient(testConfigs.ServiceBusConnectionString);
            _serviceBusTestConfig = testConfigs.AzServiceBusTestConfig;
        }
        public async Task AzServiceBus_SetupAndRunTestAsync
            (string entityName, 
            int payloadID, 
            ApplicationProperties applicationProperties)
        {
            string topicName = GetTopicName(entityName);
            string payload = _payloadFileHelper.LoadPayload(entityName, payloadID);
            await _azServiceBusTestClient
                .SendMessageToServiceBusTopicWithApplicationProperties
                (topicName,
                payload,
                applicationProperties);
        }

        private string GetTopicName(string entityName)
        {
            return _serviceBusTestConfig
                .Where(x => x.EntityName.Equals(entityName))
                .Select(x => x.TopicName)
                .FirstOrDefault();
        }
    }
}
