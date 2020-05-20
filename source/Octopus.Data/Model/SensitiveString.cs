using System;

namespace Octopus.Data.Model
{
    public class SensitiveString : IEquatable<SensitiveString>, IEquatable<string>
    {
        public SensitiveString()
        {}
        
        public SensitiveString(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public bool Equals(SensitiveString other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public bool Equals(string other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SensitiveString) obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }

        public static bool operator ==(SensitiveString s1, SensitiveString s2)
        {
            return s1?.Value == s2?.Value;
        }
        public static bool operator !=(SensitiveString s1, SensitiveString s2)
        {
            return s1?.Value != s2?.Value;
        }

        public static bool operator ==(SensitiveString s1, string s2)
        {
            return s1?.Value == s2;
        }
        public static bool operator !=(SensitiveString s1, string s2)
        {
            return s1?.Value != s2;
        }
    }

    public static class SensitiveStringExtensions
    {
        public static SensitiveString ToSensitiveString(this string s)
        {
            return new SensitiveString(s);
        }
    }
}