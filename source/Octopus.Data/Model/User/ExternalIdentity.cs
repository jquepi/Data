namespace Octopus.Data.Model.User
{
    public class ExternalIdentity : Identity
    {
        protected ExternalIdentity()
        { }

        public ExternalIdentity(string provider, string emailAddress) : base(provider)
        {
            EmailAddress = emailAddress;
        }

        public string EmailAddress { get; set; }

        public bool HasBeenValidated { get; set; }
    }
}