using System;

namespace Octopus.Data.Model.User
{
    public class SecurityGroups
    {
        public string[] GroupIds { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
    }
}