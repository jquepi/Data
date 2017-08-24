using System;
using Newtonsoft.Json;
using Octopus.Data.Resources.Users;

namespace Octopus.Data.Model.User
{
    public abstract class Identity : IEquatable<Identity>, IEquatable<IdentityResource>
    {
        protected Identity()
        { }

        protected Identity(string provider)
        {
            Provider = provider;
        }

        public string Provider { get; }

        [JsonIgnore]
        public abstract string[] SearchableIdentifiers { get; }

        public abstract IdentityResource ToResource();

        public bool Equals(Identity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return GetHashCode() ==  other.GetHashCode();
        }

        public bool Equals(IdentityResource other)
        {
            if (ReferenceEquals(null, other)) return false;
            return EqualsResource(other);
        }

        protected abstract bool EqualsResource(IdentityResource resource);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Identity) obj);
        }

        public override int GetHashCode()
        {
            return string.Concat(SearchableIdentifiers).GetHashCode();
        }
    }
}