using System;
using System.Collections.Generic;

namespace Octopus.Data.Model.User
{
    public interface IExternalIdentity : IIdentity
    {
        string EmailAddress { get; set; }
        string ExternalId { get; }

        void SetExternalId(string externalId);

        void SetExternalSecurityGroups(IEnumerable<string> groups, DateTimeOffset updatedDateTime);
        HashSet<string> GetExternalSecurityGroups();
    }
}