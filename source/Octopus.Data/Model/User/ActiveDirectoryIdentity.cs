using System;
using System.Collections.Generic;
using Nevermore.Contracts;

namespace Octopus.Data.Model.User
{
    public class ActiveDirectoryIdentity : ExternalIdentity, IHasExternalSecurityGroups
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

        public ReferenceCollection SecurityGroupIds { get; set; }
        public DateTimeOffset? SecurityGroupsLastUpdated { get; set; }

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