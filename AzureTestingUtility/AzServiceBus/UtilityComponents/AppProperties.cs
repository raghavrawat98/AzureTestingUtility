using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTestingUtility.AzServiceBus.UtilityComponents
{
    public class AppProperties : List<AppProperty>
    {

    }

    public class AppProperty 
    {
        public AppProperty(string Key, string Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
        public readonly string Key;
        public readonly string Value;
    }
}
