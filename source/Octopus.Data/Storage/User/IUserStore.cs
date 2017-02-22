using System;
using System.Collections.Generic;
using Octopus.Data.Model.User;

namespace Octopus.Data.Storage.User
{
    public interface IUserStore
    {
        UserCreateOrUpdateResult GetOrCreateUser(string username, string displayName, string emailAddress, string externalId, ApiKeyDescriptor apiKeyDescriptor = null);

        IUser GetById(string userId);
        IUser GetByUsername(string username);
        IUser GetByIdentificationToken(Guid identificationToken);
        [Obsolete("Please use the TryGetByApiKey() method which returns both the ApiKeyDescriptor and IUser.", true)]
        IUser GetByApiKey(string apiKey);
        bool TryGetByApiKey(string apiKey, out ApiKeyDescriptor storedApiKey, out IUser user);

        UserCreateOrUpdateResult Create(string username, string displayName, string emailAddress, string externalId, ApiKeyDescriptor apiKeyDescriptor = null, string id = null, string password = null, bool isService = false, bool generateRandomPasswordOnCreate = false);

        UserCreateOrUpdateResult CreateOrUpdate(
            string username,
            string displayName, 
            string emailAddress, 
            string externalId, 
            ApiKeyDescriptor apiKeyDescriptor, 
            bool generateRandomPasswordOnCreate, 
            string password,
            bool isService,
            string[] externalGroups);

        void EnableUser(string userId);
        void DisableUser(string userId);

        void UpdateUsersExternalGroups(IUser user, HashSet<string> groups);
    }
}