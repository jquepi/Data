namespace Octopus.Data.Model.User
{
    public interface IUsernamePasswordIdentity : IIdentity
    {
        void SetPassword(string password);
        bool ValidatePassword(string plainTextPassword);
    }
}