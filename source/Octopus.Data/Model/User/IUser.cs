using System;
using System.Collections.Generic;
using Nevermore.Contracts;

namespace Octopus.Data.Model.User
{
    public interface IUser : IId
    {
        string Username { get; }
        Guid IdentificationToken { get; }

        string DisplayName { get; }
        string EmailAddress { get; }

        bool IsService { get; }

        bool IsActive { get; }
        
        ReferenceCollection ExternalIdentifiers { get; }
        
        HashSet<Identity> Identities { get; }

        SecurityGroups GetSecurityGroups(string provider);
        
        void SetPassword(string plainTextPassword);
        bool ValidatePassword(string plainTextPassword);
    }
}