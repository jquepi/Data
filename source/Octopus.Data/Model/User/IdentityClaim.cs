namespace Octopus.Data.Model.User
{
    public class IdentityClaim
    {
        public IdentityClaim()
        {}

        public IdentityClaim(string value, bool isIdentifyingClaim, bool isServerSideOnly = false)
        {
            Value = value;
            IsIdentifyingClaim = isIdentifyingClaim;
            IsServerSideOnly = isServerSideOnly;
        }

        public string Value { get; set; }

        public bool IsIdentifyingClaim { get; set; }

        public bool IsServerSideOnly { get; set; }
    }
}