using System.Collections.Generic;

namespace Octopus.Data.Storage.User
{
    public class ProviderUserGroups
    {
        public string IdentityProviderName { get; set; }
        public IEnumerable<string> GroupIds { get; set; }
    }
}