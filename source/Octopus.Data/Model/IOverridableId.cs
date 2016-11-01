using Nevermore.Contracts;

namespace Octopus.Data.Model
{
    public interface IOverridableId : IId
    {
        void SetId(string id);
    }
}