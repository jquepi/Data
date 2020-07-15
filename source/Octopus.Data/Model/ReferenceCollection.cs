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

        public ReferenceCollection Clone()
        {
            return new ReferenceCollection(this);
        }

        public override string ToString()
        {
            return string.Join(", ", this);
        }

        public static ReferenceCollection One(string item)
        {
            return new ReferenceCollection { item };
        }
    }

    public class ReferenceCollection<T> : HashSet<T>
    {
        public ReferenceCollection(IEqualityComparer<T>? comparer = null) : base(comparer)
        {
        }

        public ReferenceCollection(IEnumerable<T> values, IEqualityComparer<T>? comparer = null) : base(values, comparer)
        {
        }

        public void ReplaceAll(IEnumerable<T> newItems)
        {
            Clear();

            if (newItems == null) return;

            foreach (var item in newItems) Add(item);
        }

        public override string ToString()
        {
            return string.Join(", ", this.Where(x => x != null).Select(x => x!.ToString()));
        }
    }
}