namespace Octopus.Data.Storage.User
{
    public abstract class ExternalIdentityToMatch : IdentityToMatch
    {
        protected ExternalIdentityToMatch(string provider, string emailAddress) : base(provider)
        {
            EmailAddress = emailAddress;
        }

        public string EmailAddress { get; }
    }
}