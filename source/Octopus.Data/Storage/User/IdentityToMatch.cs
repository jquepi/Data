namespace Octopus.Data.Storage.User
{
    public abstract class IdentityToMatch
    {
        protected IdentityToMatch(string provider)
        {
            Provider = provider;
        }

        public string Provider { get; }
    }
}