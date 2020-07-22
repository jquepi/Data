using System;
using Octopus.TinyTypes;

namespace Octopus.Data.Model
{
    public interface ITypedId
    {
    }

    public class TypedId : TypedId<string>, ITypedId
    {
        public TypedId(string value) : base(value)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if ((object) this == obj)
                return true;
            return !(obj.GetType() != GetType()) && obj.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() ^ Value.GetHashCode();
        }

        public static bool operator ==(TypedId? a, TypedId? b)
        {
            if ((object?)a == null && (object?)b == null)
                return true;
            return (object?)a != null && (object?)b != null && a.Equals(b);
        }

        public static bool operator !=(TypedId a, TypedId b)
        {
            return !(a == b);
        }

        public static bool operator ==(TypedId? a, string? b)
        {
            if ((object?)a == null && b == null)
                return true;
            return (object?)a != null && a.Value.Equals(b);
        }

        public static bool operator !=(TypedId? a, string? b)
        {
            return !(a == b);
        }
    }

    public interface ITypedId<out T> : ITypedId
        where T : IComparable
    {
        T Value { get; }
    }

    public class TypedId<T> : TinyType<T>, ITypedId<T>
        where T : IComparable
    {
        public TypedId(T value) : base(value)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if ((object) this == obj)
                return true;
            return !(obj.GetType() != GetType()) && obj.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() ^ Value.GetHashCode();
        }

        public static bool operator ==(TypedId<T>? a, TypedId<T>? b)
        {
            if ((object?)a == null && (object?)b == null)
                return true;
            return (object?)a != null && (object?)b != null && a.Equals(b);
        }

        public static bool operator !=(TypedId<T>? a, TypedId<T>? b)
        {
            return !(a == b);
        }

        public static bool operator ==(TypedId<T>? a, T b)
        {
            if ((object?)a == null && b == null)
                return true;
            return (object?)a != null && b != null && a.Value.Equals(b);
        }

        public static bool operator !=(TypedId<T>? a, T b)
        {
            return !(a == b);
        }
    }
}