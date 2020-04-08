using System;

namespace Octopus.Data.Model
{
    public class EncryptedString : IEquatable<EncryptedString>, IEquatable<string>
    {
        public EncryptedString()
        {}
        
        public EncryptedString(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public bool Equals(EncryptedString other)
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
            return Equals((EncryptedString) obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }
    }
}