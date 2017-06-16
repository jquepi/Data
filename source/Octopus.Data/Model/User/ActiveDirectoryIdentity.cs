using System.Collections.Generic;

namespace Octopus.Data.Model.User
{
    public class ActiveDirectoryIdentity : ExternalIdentity
    {
        protected ActiveDirectoryIdentity()
        {}

        public ActiveDirectoryIdentity(string id, string provider, string emailAddress, string upn, string samAccountName) : base(id, provider, emailAddress)
        {
            Upn = upn;
            SamAccountName = samAccountName;
        }

        public string Upn { get; set; }
        public string SamAccountName { get; set; }

        public HashSet<string> ExternalSecurityGroups { get; set; }
    }
}