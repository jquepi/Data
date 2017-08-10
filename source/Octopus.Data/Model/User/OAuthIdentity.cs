namespace Octopus.Data.Model.User
{
    public class OAuthIdentity : ExternalIdentity
    {
        protected OAuthIdentity()
        { }

        public OAuthIdentity(string provider, string emailAddress, string externalId) : base(provider, emailAddress)
        {
            ExternalId = externalId;
        }

        public string ExternalId { get; set; }
    }
}