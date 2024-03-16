namespace AzureTestingUtility.FileHelperService
{
    public interface IFileHelper
    {
        public string LoadFile(string filePath)
        {
            string payload = File.ReadAllText(filePath);
            return payload;
        }
    }
}
