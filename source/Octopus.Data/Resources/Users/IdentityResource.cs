using System;

namespace Octopus.Data.Resources.Users
{
    public abstract class IdentityResource : IEquatable<IdentityResource>
    {
        public string Provider { get; set; }

        public bool Equals(IdentityResource other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualsResource(other);
        }

        protected abstract bool EqualsResource(IdentityResource resource);
    }
}