namespace Octopus.Data.Model.Configuration
{
    public abstract class ConfigurationDocument
    {
        protected ConfigurationDocument(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}