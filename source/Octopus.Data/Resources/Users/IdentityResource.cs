using System;
using System.Collections.Generic;
using System.Linq;
using Octopus.Data.Model.User;

namespace Octopus.Data.Resources.Users
{
    public sealed class IdentityResource : IEquatable<IdentityResource>
    {
        public IdentityResource()
        {
            Claims = new Dictionary<string, IdentityClaimResource>();
        }

        public IdentityResource(string identityProviderName) : this()
        {
            IdentityProviderName = identityProviderName;
        }

        public string IdentityProviderName { get; set; }

        public Dictionary<string, IdentityClaimResource> Claims { get; }

        public bool Equals(IdentityResource other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (IdentityProviderName != other.IdentityProviderName) return false;
            return Claims.All(kvp =>
                !kvp.Value.IsIdentifyingClaim || 
                (other.Claims.ContainsKey(kvp.Key) && kvp.Value.Value == other.Claims[kvp.Key].Value));
        }

        public Identity ToIdentity()
        {
            return new Identity(IdentityProviderName)
                .WithClaims(Claims);
        }

        internal IdentityResource WithClaims(Dictionary<string, IdentityClaim> claims)
        {
            foreach (var kvp in claims.Where(x => !x.Value.IsServerSideOnly))
            {
                if (Claims.ContainsKey(kvp.Key))
                {
                    Claims[kvp.Key].Value = kvp.Value.Value;
                }
                else
                {
                    Claims.Add(kvp.Key, new IdentityClaimResource(kvp.Value.Value, kvp.Value.IsIdentifyingClaim));
                }
            }
            return this;
        }
    }
}