using System;
using System.Collections.Generic;
using NUnit.Framework;
using Octopus.Data.Model.User;

namespace Tests
{
    [TestFixture]
    public class TypedIdTests
    {
        [Test]
        public void CanCompareUserIdToString()
        {
            var user = new UserTest("Users-1".ToUserId(), "testuser1", "testuser@octopustest.com");
            Assert.IsTrue(user.Id == "Users-1");
        }

        [Test]
        public void CanCompareUserIdToAnotherUserId()
        {
            var user = new UserTest("Users-1".ToUserId(), "testuser1", "testuser@octopustest.com");
            Assert.IsTrue(user.Id == "Users-1".ToUserId());
        }

        class UserTest : IUser
        {
            public UserTest(UserId id, string username, string emailAddress)
            {
                Id = id;
                Username = username;
                DisplayName = username;
                EmailAddress = emailAddress;
                IdentificationToken = Guid.NewGuid();
                Identities = new HashSet<Identity>();
                IsActive = true;
            }

            public UserId Id { get; }
            public string Username { get; }
            public Guid IdentificationToken { get; }
            public string DisplayName { get; set; }
            public string EmailAddress { get; set; }
            public bool IsService { get; set; }
            public bool IsActive { get; set; }
            public HashSet<Identity> Identities { get; }
            public void SetPassword(string plainTextPassword)
            {
                throw new NotImplementedException();
            }

            public bool ValidatePassword(string plainTextPassword)
            {
                throw new NotImplementedException();
            }

            public SecurityGroups GetSecurityGroups(string identityProviderName)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<string> GetSecurityGroups()
            {
                throw new NotImplementedException();
            }
        }
    }
}