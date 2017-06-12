using System;
using System.Collections.Generic;
using Octopus.Data.Model.User;

namespace Octopus.Data.Storage.User
{
    public interface IUserStore
    {
        UserCreateOrUpdateResult GetOrCreateUser(string username, string displayName, string emailAddress, string externalId, ApiKeyDescriptor apiKeyDescriptor = null);

        IUserWithIdentities GetById(string userId);
        IUser GetById(string userId, string providerName);

        IUserWithIdentities GetByUsername(string username);
        IUser GetByUsername(string username, string providerName);

        IUserWithIdentities GetByIdentificationToken(Guid identificationToken);
        IUser GetByIdentificationToken(Guid identificationToken, string providerName);

        UserCreateOrUpdateResult Create(string username, IIdentity[] identities, ApiKeyDescriptor apiKeyDescriptor = null, string id = null, bool isService = false);

        UserCreateOrUpdateResult CreateOrUpdate(
            string username,
            IIdentity[] identities, 
            ApiKeyDescriptor apiKeyDescriptor, 
            bool isService);

        void EnableUser(string userId);
        void DisableUser(string userId);

        void UpdateUsersExternalGroups(IUser user, HashSet<string> groups);

        UserFindAndUpdateResult FindAndUpdate(
            string username,
            IIdentity[] identities,
            ApiKeyDescriptor apiKeyDescriptor);
    }
}