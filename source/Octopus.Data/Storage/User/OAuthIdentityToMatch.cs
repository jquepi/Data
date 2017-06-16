namespace Octopus.Data.Storage.User
{
    public abstract class OAuthIdentityToMatch : ExternalIdentityToMatch
    {
        protected OAuthIdentityToMatch(string provider, string emailAddress, string externalId) : base(provider, emailAddress)
        {
            ExternalId = externalId;
        }

        public string ExternalId { get; }
    }
}