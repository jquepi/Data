using System;
using System.Diagnostics;

namespace Octopus.Data.Model
{
    [DebuggerDisplay("Sensitive: {Value}")]
    public class SensitiveString
    {
        internal SensitiveString(string? value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value),
                    "SensitiveString values should never be null. If the value you want to communicate is null then " +
                    "just pass a null rather than a SensitiveString wrapping a null.");

            Value = value;
        }

        public string Value { get; }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        protected bool Equals(SensitiveString? other)
        {
            return Value == other?.Value;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SensitiveString) obj);
        }

        public static bool operator ==(SensitiveString? s1, object? s2)
        {
            if (s2 is SensitiveString other)
                return s1?.Value == other?.Value;
            if (s2 is string otherString)
                return s1?.Value == otherString;
            return ReferenceEquals(s1, null) && ReferenceEquals(s2, null);
        }
        public static bool operator !=(SensitiveString s1, object? s2)
        {
            return !(s1 == s2);
        }
    }

    public static class SensitiveStringExtensionMethods
    {
        public static SensitiveString ToSensitiveString(this string s)
        {
            return new SensitiveString(s);
        }
    }
}