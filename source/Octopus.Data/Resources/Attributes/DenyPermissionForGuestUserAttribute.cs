using System;

namespace Octopus.Data.Resources.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DenyPermissionForGuestUserAttribute : Attribute
    {
    }
}