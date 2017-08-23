using Newtonsoft.Json;

namespace Octopus.Data.Model.User
{
    public abstract class Identity
    {
        protected Identity()
        { }

        protected Identity(string provider)
        {
            Provider = provider;
        }

        public string Provider { get; }

        [JsonIgnore]
        public abstract string SearchableIdentifier { get; }
    }
}