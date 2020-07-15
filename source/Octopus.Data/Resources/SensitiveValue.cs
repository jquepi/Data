using System;
using Octopus.Data.Model;

namespace Octopus.Data.Resources
{
    public class SensitiveValue : IEquatable<SensitiveValue>
    {
        public bool HasValue { get; set; }
        public string? NewValue { get; set; }

        public bool Equals(SensitiveValue other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.HasValue, HasValue) && Equals(other.NewValue, NewValue);
        }

        public static implicit operator SensitiveValue(string newValue)
        {
            return new SensitiveValue { HasValue = newValue != null };
        }

        public static implicit operator SensitiveValue(SensitiveString newValue)
        {
            return new SensitiveValue { HasValue = newValue?.Value != null };
        }
    }
}