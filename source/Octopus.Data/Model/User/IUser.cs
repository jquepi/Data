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

        void ClearSecurityGroupIds(string provider);
        SecurityGroups GetSecurityGroups(string provider);
        void SetSecurityGroupIds(string provider, IEnumerable<string> ids, DateTimeOffset updated);
        
        void SetPassword(string plainTextPassword);
        bool ValidatePassword(string plainTextPassword);
    }
}