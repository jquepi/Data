using System;
using Octopus.Data.Model.User;
using Octopus.Server.MessageContracts.Features.Users;

namespace Octopus.Data.Storage.User
{
    public interface IUserStore
    {
        IUser GetById(UserId userId);
        IUser GetByUsername(string username);
        IUser[] GetByEmailAddress(string emailAddress);
        IUser GetByIdentificationToken(Guid identificationToken);

        IUser[] GetByIdentity(Identity identityToMatch);
    }
}