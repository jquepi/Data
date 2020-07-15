using System;
using System.Collections.Generic;
using System.Linq;

namespace Octopus.Data.Storage.User
{
    public class ProviderUserGroups
    {
        public string IdentityProviderName { get; set; } = string.Empty;
        public IEnumerable<string> GroupIds { get; set; } = Enumerable.Empty<string>();
    }
}