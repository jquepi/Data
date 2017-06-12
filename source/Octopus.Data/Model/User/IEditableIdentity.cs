namespace Octopus.Data.Model.User
{
    public interface IEditableIdentity : IIdentity
    {
        void SetDisplayName(string displayName);
    }
}