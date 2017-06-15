namespace Octopus.Data.Model.User
{
    public interface IExternalIdentity : IIdentity
    {
        string EmailAddress { get; }

        void SetEmailAddress(string emailAddress);
    }
}