using Nevermore.Contracts;

namespace Octopus.Data.Model.User
{
    public interface IIdentity : IId
    {
        string Provider { get; }
    }
}