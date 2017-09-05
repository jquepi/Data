using System;

namespace Octopus.Data.Model.User
{
    public struct SecurityGroups
    {
        public string[] GroupIds { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
    }
}