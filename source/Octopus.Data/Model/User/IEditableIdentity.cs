namespace Octopus.Data.Model.User
{
    public interface IEditableIdentity : IIdentity
    {
        void SetEmailAddress(string emailAddress);

        void SetDisplayName(string displayName);
    }
}