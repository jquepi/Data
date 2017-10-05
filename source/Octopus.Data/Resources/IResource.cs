using Octopus.Data.Model;

namespace Octopus.Data.Resources
{
    /// <summary>
    /// Implemented by all resources.
    /// </summary>
    public interface IResource
    {
        /// <summary>
        /// Gets a unique identifier for this resource.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets or sets a dictionary of links to other related resources. These links can be used to navigate the resources on
        /// the server.
        /// </summary>
        LinkCollection Links { get; set; }
    }
}