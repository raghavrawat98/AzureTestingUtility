﻿using AzureTestingUtility.AzFunc;
using AzureTestingUtility.FileHelperService.PayloadFileHelper;
using AzureTestingUtility.TestConfigurations;

namespace AzureTestingUtility.AzTestCases
{
    public class AzFuncTestCase
    {
        private IAzFuncTestClient _azFuncTestClient;
        private List<AzFunctionTestConfig> _azFunctionTestConfigs;
        private PayloadFileHelper _payloadFileHelper;

        public AzFuncTestCase(
            TestConfigs testConfigs
            ) 
        {
            _payloadFileHelper = new PayloadFileHelper(testConfigs);
            _azFunctionTestConfigs = testConfigs.AzFunctionTestConfig;
            _azFuncTestClient = new AzFuncTestClient();
        }

        public async Task AzFunc_SetupAndRunTestAsync(
            string entityName, 
            int payloadID)
        {
            string apiUrl = GetApiUrl(entityName);
            string payload = _payloadFileHelper.LoadPayload(entityName,payloadID);
            await _azFuncTestClient.SendPostRequest
                (apiUrl,
                payload);
        }

        private string GetApiUrl(string entityName) 
        {
            return _azFunctionTestConfigs
                .Where(x => x.EntityName.Equals(entityName))
                .Select(x => x.ApiUrl)
                .FirstOrDefault();
        }
    }
}