using AzureTestingUtility.TestConfigurations;

namespace AzureTestingUtility.FileHelperService.PayloadFileHelper
{
    public class PayloadFileHelper : FileHelper
    {
        private string _pathOfTestPayloadFolder;
        private List<PairOfEntitiesPayloads> _pairOfEntitiesPayloads;

        public PayloadFileHelper(TestConfigs testConfigs)
        {
            _pathOfTestPayloadFolder = testConfigs.TestPayloadsFolderPath;

            List<PairOfEntitiesPayloads> pairsFromFunction = testConfigs
                                        .AzFunctionTestConfig
                                        .Select(Mapper.MapFromAzFunctionTestConfig).ToList();

            List<PairOfEntitiesPayloads> pairsFromServiceBus = testConfigs
                                        .AzServiceBusTestConfig
                                        .Select(Mapper.MapFromAzServiceBusTestConfig).ToList();

            _pairOfEntitiesPayloads = pairsFromFunction.Union(pairsFromServiceBus).ToList();
        }

        public string LoadPayload(string entityName, int payloadId)
        {
            string filePath = GetPath(entityName, payloadId);
            string completefilePath = _pathOfTestPayloadFolder + filePath;
            string payload = File.ReadAllText(completefilePath);

            return payload;
        }

        private string GetPath(string entityName, int payloadId) 
        {
            return _pairOfEntitiesPayloads
                .Where(x => x.EntityName.Equals(entityName))
                .Select(x => x.Paths[payloadId-1])
                .FirstOrDefault();
        }

    }
}
