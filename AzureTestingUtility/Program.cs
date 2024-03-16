using AzureTestingUtility.AzFunc;
using AzureTestingUtility.AzServiceBus;
using AzureTestingUtility.AzServiceBus.UtilityComponents;
using AzureTestingUtility.AzTestRunner;
using AzureTestingUtility.TestConfigurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AzureTestingUtility
{
    public class Program
    {
        
        static async Task Main(string[] args)
        {
            // Setup configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("testConfigs.json", optional: true, reloadOnChange: true)
                .Build();

            // Setup dependency injection and bind settings
            var serviceProvider = new ServiceCollection()
                .Configure<TestConfigs>(configuration.GetSection("TestConfigs"))
                .BuildServiceProvider();

            // Get the configured instance of AppSettings
            TestConfigs testConfigs = serviceProvider.GetRequiredService<IOptions<TestConfigs>>().Value;

            TestRunner testRunner = new TestRunner(testConfigs);
            await testRunner.ExecuteAsync();


            // await MyFunctionAppTestAsync();
            // await MyServiceBusTestAsync();
            Console.WriteLine("----Testing END-----");
        }

        static async Task MyFunctionAppTestAsync() 
        {
            // Initialize Client
            IAzFuncTestClient funcTestClient = new AzFuncTestClient();

            // Set api url and payload
            string apiUrl = @"https://postreqfunctest.azurewebsites.net/api/Function1?";
            string payload = "{\"key1\":\"value1\",\"key2\":\"value2\"}";

            // Sending Request
            Console.WriteLine("Starting to send Request..");
            await funcTestClient.SendPostRequest
                (apiUrl,
                payload);
            Console.WriteLine("Ending..");
        }

        static async Task MyServiceBusTestAsync() 
        {
            Console.WriteLine("Starting to Send Service Bus Payload...");

            // Initialize Client with Service Bus Connection String
            string[] sbConnections = new string[2];

            //dev
            sbConnections[0] = @"Endpoint=sb://myservicebusforpoctesting.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=pp3dafmxizE+OKkjYAeg3VvSM7B0w3NSA+ASbB2jxFc=";
            //test
            sbConnections[1] = @"";
            IAzServiceBusTestClient sbTestClient = new AzServiceBusTestClient(
                sbConnections
                );

            // Fill payload
            string payload = "Hello, Service Bus with Application Properties!";

            // Set Topic Name
            string topicName = "trendingtopic";
            
            // Add Application Properties
            AppProperties appProperties = new AppProperties {
                new AppProperty("abc", "123"),
                new AppProperty("xyz", "456"),
            };

            // Send
            await sbTestClient.SendMessageToServiceBusTopicWithApplicationProperties
                (topicName,
                payload,
                appProperties,
                SBEnvironments.Dev);

            Console.WriteLine("End.");
        }
    }
}
