using System;
using System.Threading;
using Octopus.Data.Model.User;

namespace Octopus.Data.Storage.User
{
    public interface IUserStore
    {
        IUser GetById(string userId);
        IUser GetByUsername(string username);
        IUser GetByIdentificationToken(Guid identificationToken);

        UserCreateOrUpdateResult CreateOrUpdate(
            string username,
            string displayName,
            string emailAddress,
            string password,
            bool isService,
            Identity providerIdentity,
            CancellationToken cancellationToken,
            ProviderUserGroups providerGroups = null);

        void EnableUser(string userId);
        void DisableUser(string userId);
    }
}