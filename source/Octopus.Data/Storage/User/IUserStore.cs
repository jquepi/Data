using System;
using System.Collections.Generic;
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
            string externalId,
            string password,
            bool isService,
            CancellationToken cancellationToken);

        void SetExternalSecurityGroups(string userId, string providerName, IEnumerable<string> groupsIds);

        void EnableUser(string userId);
        void DisableUser(string userId);
    }
}