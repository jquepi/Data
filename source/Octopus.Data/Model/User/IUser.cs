using System;
using System.Collections.Generic;
using Nevermore.Contracts;

namespace Octopus.Data.Model.User
{
    public interface IUser : IId
    {
        string Username { get; }
        string DisplayName { get; set; }
        string EmailAddress { get; set; }
        string ExternalId { get; }

        Guid IdentificationToken { get; }

        DateTimeOffset? SecurityGroupsLastUpdated { get; set; }

        bool HasSecurityGroupIds { get; }

        bool IsService{ get; set; }

        bool IsActive { get; set; }

        void SetPassword(string password);
        bool ValidatePassword(string plainTextPassword);

        void SetExternalId(string externalId);

        void SetExternalSecurityGroups(IEnumerable<string> groups, DateTimeOffset updatedDateTime);
        HashSet<string> GetExternalSecurityGroups();
    }
}