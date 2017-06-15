using System;
using System.Collections.Generic;

namespace Octopus.Data.Model.User
{
    public interface IOAuthIdentity : IExternalIdentity
    {
        string ExternalId { get; }

        HashSet<string> GetExternalSecurityGroups();

        void SetExternalId(string externalId);

        void SetExternalSecurityGroups(IEnumerable<string> groups, DateTimeOffset updatedDateTime);
    }
}