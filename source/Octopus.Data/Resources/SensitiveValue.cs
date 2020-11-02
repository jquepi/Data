using System;
using Octopus.Data.Model;

namespace Octopus.Data.Resources
{
    public class SensitiveValue
    {
        public bool HasValue { get; set; }
        public string? NewValue { get; set; }
        public string? Hint { get; set; }

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