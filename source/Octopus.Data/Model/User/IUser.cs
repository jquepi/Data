using System;
using System.Collections.Generic;

namespace Octopus.Data.Model.User
{
    public interface IUser : IId
    {
        string Username { get; }
        Guid IdentificationToken { get; }

        string DisplayName { get; set; }
        string EmailAddress { get; set; }

        bool IsService { get; set; }

        bool IsActive { get; set; }

        HashSet<Identity> Identities { get; }

        void SetPassword(string plainTextPassword);
        bool ValidatePassword(string plainTextPassword);
        SecurityGroups GetSecurityGroups(string identityProviderName);
        IEnumerable<string> GetSecurityGroups();
    }
}