using System;
using System.Collections.Generic;

namespace Octopus.Data.Model.User
{
    public interface IExternalIdentity : IIdentity
    {
        string ExternalId { get; }

        HashSet<string> GetExternalSecurityGroups();
    }
}