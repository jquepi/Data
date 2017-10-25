using System;

namespace Octopus.Data.Resources
{
    public class SensitiveValue : IEquatable<SensitiveValue>
    {
        public bool HasValue { get; set; }
        public string NewValue { get; set; }

        public static implicit operator SensitiveValue(string newValue)
        {
            return new SensitiveValue { HasValue = newValue != null };
        }

        public bool Equals(SensitiveValue other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.HasValue, HasValue) && Equals(other.NewValue, NewValue);
        }
    }
}
