using System;
using System.Collections.Generic;
using Nevermore.Contracts;

namespace Octopus.Data.Model.User
{
    public interface IHasExternalSecurityGroups
    {
        ReferenceCollection SecurityGroupIds { get; }
        DateTimeOffset? SecurityGroupsLastUpdated { get; }

        void ClearSecurityGroupIds();
        void SetSecurityGroupIds(IEnumerable<string> ids, DateTimeOffset updated);
    }
}