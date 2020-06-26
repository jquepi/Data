namespace Octopus.Data.Storage.User
{
    public class ApiKeyDescriptor
    {
        public ApiKeyDescriptor(string purpose)
        {
            Purpose = purpose;
        }

        public ApiKeyDescriptor(string purpose, string apiKey)
        {
            Purpose = purpose;
            ApiKey = apiKey;
        }

        public string Purpose { get; }
        public string ApiKey { get; set; }
    }
}