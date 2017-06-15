using System;
using System.Collections.Generic;

namespace Octopus.Data.Model.User
{
    public interface IActiveDirectoryIdentity : IExternalIdentity
    {
        string Upn { get; }
        string SamAccountName { get; }

        HashSet<string> GetExternalSecurityGroups();

        void SetUpnAndSamAccountName(string upn, string samAccountName);

        void SetExternalSecurityGroups(IEnumerable<string> groups, DateTimeOffset updatedDateTime);
    }
}