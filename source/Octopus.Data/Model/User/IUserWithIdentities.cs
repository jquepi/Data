using System;
using System.Collections.Generic;
using Nevermore.Contracts;

namespace Octopus.Data.Model.User
{
    public interface IUserWithIdentities : IId
    {
        string Username { get; }
        Guid IdentificationToken { get; }

        bool IsService { get; set; }

        bool IsActive { get; set; }

        /// <summary>
        /// The Ids from the external authentication providers
        /// </summary>
        ReferenceCollection ExternalIds { get; }

        List<IIdentity> ExternalIdentities { get; set; }
    }
}