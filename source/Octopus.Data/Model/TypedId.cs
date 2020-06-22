using Octopus.TinyTypes;

namespace Octopus.Data.Model
{
    public class TypedId : TinyType<string>
    {
        public TypedId(string value) : base(value)
        {
        }
    }
}