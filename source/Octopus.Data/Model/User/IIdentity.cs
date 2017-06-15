using Nevermore.Contracts;

namespace Octopus.Data.Model.User
{
    public interface IIdentity : IDocument
    {
        string Provider { get; }
    }
}