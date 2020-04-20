using System;
using System.Collections.Generic;
using System.Linq;

namespace Octopus.Data.Model
{
    public class ReferenceCollection : ReferenceCollection<string>
    {
        public ReferenceCollection()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        public ReferenceCollection(string singleValue)
            : this(new[] { singleValue })
        {
        }

        public ReferenceCollection(IEnumerable<string> values)
            : base(values ?? new string[0], StringComparer.OrdinalIgnoreCase)
        {
        }

        public override string ToString()
        {
            return string.Join(", ", this);
        }

        public new static ReferenceCollection One(string item)
        {
            return new ReferenceCollection { item };
        }
    }

    public class ReferenceCollection<T> : HashSet<T>
    {
        public ReferenceCollection(IEqualityComparer<T> comparer = null) : base(comparer)
        {
        }

        public ReferenceCollection(IEnumerable<T> values, IEqualityComparer<T> comparer = null) : base(values, comparer)
        {
        }

        public void ReplaceAll(IEnumerable<T> newItems)
        {
            Clear();

            if (newItems == null) return;

            foreach (var item in newItems)
            {
                Add(item);
            }
        }

        public ReferenceCollection<T> Clone()
        {
            return new ReferenceCollection<T>(this);
        }

        public override string ToString()
        {
            return string.Join(", ", this.Select(x => x.ToString()));
        }

        public static ReferenceCollection<T> One(T item)
        {
            return new ReferenceCollection<T> { item };
        }
    }
}