using AzureTestingUtility.TestConfigurations.Utils;
using System.Text;

namespace AzureTestingUtility.AzFunc
{
    public class AzFuncTestClient : IAzFuncTestClient
    {
        public async Task SendPostRequest(string apiUrl, string jsonPayload)
        {
            using (HttpClient _httpClient = new HttpClient())
            {
                try
                {
                    jsonPayload.PrintPayload();
                    // Convert the payload to a StringContent object
                    StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    // Send the POST request
                    HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

                    // Check if the request was successful (status code 2xx)
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        //Console.WriteLine($"Request successful. Response: {responseContent}");
                        responseContent.PrintSuccessResponse();
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        $"Request failed.\n Response: {responseContent}\nStatus code: {response.StatusCode}"
                            .PrintFailureResponse();
                        //Console.WriteLine($"Request failed. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }
    }
}
