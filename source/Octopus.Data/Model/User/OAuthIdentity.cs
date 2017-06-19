using System;
using System.Collections.Generic;
using Nevermore.Contracts;

namespace Octopus.Data.Model.User
{
    public class OAuthIdentity : ExternalIdentity, IHasExternalSecurityGroups
    {
        protected OAuthIdentity()
        {}

        public OAuthIdentity(string provider, string emailAddress, string externalId) : base(provider, emailAddress)
        {
            ExternalId = externalId;
        }

        public string ExternalId { get; set; }

        public ReferenceCollection SecurityGroupIds { get; set; }
        public DateTimeOffset? SecurityGroupsLastUpdated { get; private set; }
        
        public void ClearSecurityGroupIds()
        {
            SecurityGroupIds.Clear();
            SecurityGroupsLastUpdated = null;
        }

        public void SetSecurityGroupIds(IEnumerable<string> ids, DateTimeOffset updated)
        {
            SecurityGroupIds = new ReferenceCollection(ids);
            SecurityGroupsLastUpdated = updated;
        }
    }
}