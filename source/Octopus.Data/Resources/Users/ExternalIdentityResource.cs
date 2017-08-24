namespace Octopus.Data.Resources.Users
{
    public abstract class ExternalIdentityResource : IdentityResource
    {
        public string EmailAddress { get; set; }
    }
}