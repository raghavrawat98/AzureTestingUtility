namespace AzureTestingUtility.TestConfigurations.Utils
{
    public static class LoggerExtensions
    {
        public static void PrintEntityName(this string entityName)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"  |{entityName}");
            Console.ResetColor();
        }
        public static void PrintPayload(this string payload)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Payload >");
            Console.WriteLine(payload);
            Console.ResetColor();
        }
        public static void PrintSuccessResponse(this string response)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($":PASSED: {response}");
            Console.ResetColor();
        }
        public static void PrintFailureResponse(this string response)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($":FAILED: {response}");
            Console.ResetColor();
        }
        public static void PrintEnv(this string env)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"    #{env}");
            Console.ResetColor();
        }
    }
}
