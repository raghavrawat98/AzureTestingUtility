using AzureTestingUtility.TestConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTestingUtility.FileHelperService.PayloadFileHelper
{
    public class Mapper
    {
        public static PairOfEntitiesPayloads MapFromAzFunctionTestConfig(AzFunctionTestConfig config)
        {
            return new PairOfEntitiesPayloads
            {
                EntityName = config.EntityName,
                Paths = config.PayloadPaths
            };
        }

        public static PairOfEntitiesPayloads MapFromAzServiceBusTestConfig(AzServiceBusTestConfig config)
        {
            return new PairOfEntitiesPayloads
            {
                EntityName = config.EntityName,
                Paths = config.PayloadPaths
            };
        }
    }
}
