using System;
using System.Collections.Generic;

namespace Octopus.Data.Model.User
{
    public interface IEditableExternalIdentity : IExternalIdentity, IEditableIdentity
    {
        void SetEmailAddress(string emailAddress);

        void SetExternalId(string externalId);

        void SetExternalSecurityGroups(IEnumerable<string> groups, DateTimeOffset updatedDateTime);

    }
}