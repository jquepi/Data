using System;
using Octopus.Data.Model.User;

namespace Octopus.Data.Storage.User
{
    public interface IUserStore
    {
        IUser GetById(string userId);
        IUser GetByUsername(string username);
        IUser GetByIdentificationToken(Guid identificationToken);

        IUser GetByIdentity(IIdentity identityToMatch);
    }
}