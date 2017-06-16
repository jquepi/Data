using System.Collections.Generic;

namespace Octopus.Data.Model.User
{
    public class OAuthIdentity : ExternalIdentity
    {
        protected OAuthIdentity()
        {}

        public OAuthIdentity(string id, string provider, string emailAddress, string externalId) : base(id, provider, emailAddress)
        {
            ExternalId = externalId;
        }

        public string ExternalId { get; set; }

        public HashSet<string> ExternalSecurityGroups { get; set; }
    }
}