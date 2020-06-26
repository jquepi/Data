using System;

namespace Octopus.Data.Resources.Attributes
{
    /// <summary>
    ///     When applied to a Resource it won't generate APIs that use the Resource in the Swagger documentation generation
    ///     and it won't require the Resource to be apart of Octopus.Client
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ExperimentalAttribute : Attribute
    {
    }
}