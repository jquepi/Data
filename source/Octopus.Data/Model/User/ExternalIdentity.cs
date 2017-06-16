namespace Octopus.Data.Model.User
{
    public class ExternalIdentity : Identity
    {
        protected ExternalIdentity()
        {}

        public ExternalIdentity(string id, string provider, string emailAddress) : base(id, provider)
        {
            EmailAddress = emailAddress;
        }

        public string EmailAddress { get; set; }
        
        public bool HasBeenValidated { get; set; }
    }
}