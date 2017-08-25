using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Octopus.Data.Resources.Users;

namespace Octopus.Data.Model.User
{
    public sealed class Identity : IEquatable<Identity>, IEquatable<IdentityResource>
    {
        public Identity()
        {
            Claims = new Dictionary<string, IdentityClaim>();
        }

        public Identity(string provider) : this()
        {
            Provider = provider;
        }

        public string Provider { get; }

        public Dictionary<string, IdentityClaim> Claims { get; }

        [JsonIgnore]
        public string[] SearchableIdentifiers => Claims.Where(kvp => kvp.Value.IsIdentifyingClaim && !string.IsNullOrWhiteSpace(kvp.Value.Value)).Select(kvp => Provider + ":" + kvp.Value.Value).ToArray();

        public IdentityResource ToResource()
        {
            return new IdentityResource(Provider)
                .WithClaims(Claims);
        }

        internal Identity WithClaims(Dictionary<string, IdentityClaimResource> claims)
        {
            foreach (var kvp in claims)
            {
                if (Claims.ContainsKey(kvp.Key))
                {
                    Claims[kvp.Key].Value = kvp.Value.Value;
                }
                else
                {
                    Claims.Add(kvp.Key, new IdentityClaim(kvp.Value.Value, kvp.Value.IsIdentifyingClaim));
                }
            }
            return this;
        }

        public Identity WithClaim(string type, string value, bool isIdentifyingClaim, bool isServerSideOnly = false)
        {
            if (Claims.ContainsKey(type))
            {
                var claim = Claims[type];
                claim.Value = value;
                claim.IsIdentifyingClaim = isIdentifyingClaim;
                claim.IsServerSideOnly = isServerSideOnly;
            }
            else
            {
                var claim = new IdentityClaim(value, isIdentifyingClaim, isServerSideOnly);
                Claims.Add(type, claim);
            }
            return this;
        }

        public bool Equals(Identity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (Provider != other.Provider) return false;
            return Claims.All(kvp =>
                !kvp.Value.IsIdentifyingClaim ||
                (other.Claims.ContainsKey(kvp.Key) && kvp.Value.Value == other.Claims[kvp.Key].Value));
        }

        public bool Equals(IdentityResource other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (Provider != other.Provider) return false;
            return Claims.All(kvp =>
                !kvp.Value.IsIdentifyingClaim ||
                kvp.Value.IsServerSideOnly ||
                (other.Claims.ContainsKey(kvp.Key) && kvp.Value.Value == other.Claims[kvp.Key].Value));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Identity) obj);
        }

        public override int GetHashCode()
        {
            return string.Concat(SearchableIdentifiers).GetHashCode();
        }
    }
}