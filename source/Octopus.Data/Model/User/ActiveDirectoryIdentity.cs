using System;

namespace Octopus.Data.Model.User
{
    public class ActiveDirectoryIdentity : ExternalIdentity
    {
        protected ActiveDirectoryIdentity()
        {}

        public ActiveDirectoryIdentity(string provider, string emailAddress, string upn, string samAccountName) : base(provider, emailAddress)
        {
            Upn = upn;
            SamAccountName = samAccountName;
        }

        public string Upn { get; set; }
        public string SamAccountName { get; set; }
    }
}