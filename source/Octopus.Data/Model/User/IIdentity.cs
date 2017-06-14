using Nevermore.Contracts;

namespace Octopus.Data.Model.User
{
    public interface IIdentity : IDocument
    {
        string UserId { get; }
        
        string Provider { get; }

        string EmailAddress { get; }
    }
}