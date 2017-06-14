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

        bool IsService { get; set; }

        bool IsActive { get; set; }
    }
}