using System.Collections.Generic;

namespace Octopus.Data.Storage.User
{
    public class ProviderUserGroups
    {
        public string ProviderName { get; set; }
        public IEnumerable<string> GroupIds { get; set; }
    }
}