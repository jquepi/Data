namespace Octopus.Data.Storage.User
{
    public class OAuthIdentityToMatch : ExternalIdentityToMatch
    {
        public OAuthIdentityToMatch(string provider, string emailAddress, string externalId) : base(provider, emailAddress)
        {
            ExternalId = externalId;
        }

        public string ExternalId { get; }
    }
}