using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTestingUtility.AzFunc
{
    public interface IAzFuncTestClient
    {
        public Task SendPostRequest(string apiUrl, string jsonPayload);
    }
}
