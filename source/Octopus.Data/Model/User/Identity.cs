using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Octopus.Data.Model.User
{
    public sealed class Identity : IEquatable<Identity>
    {
        public Identity(string identityProviderName)
        {
            IdentityProviderName = identityProviderName;
            Claims = new Dictionary<string, IdentityClaim>();
        }

        public string IdentityProviderName { get; }

        public Dictionary<string, IdentityClaim> Claims { get; }

        [JsonIgnore]
        public string[] SearchableIdentifiers => Claims
            .Where(kvp => kvp.Value.IsIdentifyingClaim && !string.IsNullOrWhiteSpace(kvp.Value.Value))
            .Select(kvp => IdentityProviderName + ":" + kvp.Value.Value)
            .ToArray();

        public bool Equals(Identity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (IdentityProviderName != other.IdentityProviderName) return false;
            return Claims.All(kvp =>
            {
                if (!kvp.Value.IsIdentifyingClaim)
                    return true;
                if (!other.Claims.ContainsKey(kvp.Key))
                    return false;
                var existingClaimValue = kvp.Value.Value;
                var bothClaimsAreNullOrWhitespace = string.IsNullOrWhiteSpace(existingClaimValue) &&
                    string.IsNullOrWhiteSpace(other.Claims[kvp.Key].Value);
                var existingClaimHasValueAndMatches = !string.IsNullOrWhiteSpace(existingClaimValue) &&
                    existingClaimValue.Equals(other.Claims[kvp.Key].Value,
                        StringComparison.OrdinalIgnoreCase);
                return bothClaimsAreNullOrWhitespace || existingClaimHasValueAndMatches;
            });
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Identity)obj);
        }

        public override int GetHashCode()
        {
            return string.Concat(SearchableIdentifiers).GetHashCode();
        }
    }
}