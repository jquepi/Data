using Octopus.Data.Model.User;

namespace Octopus.Data.Storage.User
{
    public class UserFindAndUpdateResult
    {
        public UserFindAndUpdateResult(IUserWithIdentities user)
        {
            User = user;
            Succeeded = true;
        }

        public UserFindAndUpdateResult(string failureReason)
        {
            FailureReason = failureReason;
        }

        public bool Succeeded { get; private set; }
        public IUserWithIdentities User { get; private set; }
        public string FailureReason { get; private set; }
    }
}