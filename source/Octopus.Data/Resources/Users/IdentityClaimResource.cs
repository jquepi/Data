
namespace Octopus.Data.Resources.Users
{
    public class IdentityClaimResource
    {
        public IdentityClaimResource()
        {
        }

        public IdentityClaimResource(string? value, bool isIdentifyingClaim)
        {
            Value = value;
            IsIdentifyingClaim = isIdentifyingClaim;
        }

        public string? Value { get; set; }

        public bool IsIdentifyingClaim { get; set; }
    }
}