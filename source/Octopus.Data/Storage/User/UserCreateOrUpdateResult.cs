﻿using System;
using Octopus.Data.Model.User;

namespace Octopus.Data.Storage.User
{
    public class UserCreateOrUpdateResult
    {
        public UserCreateOrUpdateResult(IUserWithIdentities user)
        {
            Succeeded = user != null;
            User = user;
        }

        public UserCreateOrUpdateResult(string failureReason)
        {
            if (string.IsNullOrWhiteSpace(failureReason))
                throw new ArgumentException("User creation failure reason not provided", nameof(failureReason));
            FailureReason = failureReason;
        }

        public UserCreateOrUpdateResult(UserCreateOrUpdateResult copyFrom)
        {
            Succeeded = copyFrom.Succeeded;
            User = copyFrom.User;
            FailureReason = copyFrom.FailureReason;
        }

        public bool Succeeded { get; private set; }
        public IUserWithIdentities User { get; private set; }
        public string FailureReason { get; private set; }
    }
}