namespace Octopus.Data.Model.User
{
    public interface IUsernamePasswordIdentity : IIdentity
    {
        void SetPassword(string plainTextPassword);

        bool ValidatePassword(string plainTextPassword);
    }
}