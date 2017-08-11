﻿using System;
using System.Collections.Generic;
using Nevermore.Contracts;

namespace Octopus.Data.Model.User
{
    public interface IUser : IId
    {
        string Username { get; }
        Guid IdentificationToken { get; }

        string DisplayName { get; set; }
        string EmailAddress { get; set; }

        string ExternalId { get; }

        bool IsService{ get; set; }

        bool IsActive { get; set; }

        ReferenceCollection ExternalIdentifiers { get; }

        HashSet<Identity> Identities { get; }

        void SetPassword(string plainTextPassword);
        bool ValidatePassword(string plainTextPassword);

        void SetExternalId(string externalId);

        SecurityGroups GetSecurityGroups(string provider);
        IEnumerable<string> GetSecurityGroups();
    }
}