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
        public static UserId ToUserId(this string value)
        {
            return new UserId(value);
        }
    }
}