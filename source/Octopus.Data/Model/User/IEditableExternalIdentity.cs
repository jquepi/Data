using System;
using System.Collections.Generic;

namespace Octopus.Data.Model.User
{
    public interface IEditableExternalIdentity : IExternalIdentity, IEditableIdentity
    {
        void SetExternalId(string externalId);

        void SetExternalSecurityGroups(IEnumerable<string> groups, DateTimeOffset updatedDateTime);
    }
}