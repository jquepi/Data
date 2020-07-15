using System;
using System.Collections.Generic;

namespace Octopus.Data.Resources.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class SupportsRestrictionAttribute : Attribute
    {
        public SupportsRestrictionAttribute(params string[] scopes)
        {
            Scopes = (IList<string>)scopes ?? new List<string>();
        }

        public IList<string> Scopes { get; }

        public bool ExplicitTenantScopeRequired { get; set; }
    }
}