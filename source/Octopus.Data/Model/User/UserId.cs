using System.Diagnostics.CodeAnalysis;

namespace Octopus.Data.Model.User
{
    public class UserId : TypedId
    {
        public UserId(string value) : base(value)
        {
        }
    }

    public static class UserIdExtensionMethods
    {
        [return: NotNullIfNotNull("value")]
        public static UserId? ToUserId(this string? value)
        {
            return value == null ? null : new UserId(value);
        }
    }
}