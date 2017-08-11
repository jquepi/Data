namespace Octopus.Data.Storage.User
{
    public class ActiveDirectoryIdentityToMatch : ExternalIdentityToMatch
    {
        public ActiveDirectoryIdentityToMatch(string provider, string emailAddress, string upn, string samAccountName) : base(provider, emailAddress)
        {
            Upn = upn;
            SamAccountName = samAccountName;
        }

        public string Upn { get; }
        public string SamAccountName { get; }
    }
}