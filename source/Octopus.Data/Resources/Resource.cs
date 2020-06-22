using System;
using Newtonsoft.Json;
using Octopus.Data.Model;

namespace Octopus.Data.Resources
{
    /// <summary>
    /// Base class for all resources.
    /// </summary>
    public abstract class Resource : IResource, IAuditedResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Resource" /> class.
        /// </summary>
        protected Resource()
        {
            Links = new LinkCollection();
        }

        /// <summary>
        /// Gets or sets a unique identifier for this resource.
        /// </summary>
        [JsonProperty(Order = -100, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date/time that this resource was last modified.
        /// </summary>
        [JsonProperty(Order = 1001, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets the username of the user who last modified this resource.
        /// </summary>
        [JsonProperty(Order = 1002, NullValueHandling = NullValueHandling.Ignore)]
        public string LastModifiedBy { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a dictionary of links to other related resources. These links can be used to navigate the resources on
        /// the server.
        /// </summary>
        [JsonProperty(Order = 1003)]
        public LinkCollection Links { get; set; }

        /// <summary>
        /// Determines whether the specified link exists.
        /// </summary>
        /// <param name="name">The name/key of the link.</param>
        /// <returns>
        /// <c>true</c> if the specified link is defined; otherwise, <c>false</c>.
        /// </returns>
        public bool HasLink(string name)
        {
            return (Links ?? new LinkCollection()).TryGetValue(name, out Href value);
        }

        /// <summary>
        /// Gets the link with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">If the link is not defined.</exception>
        public string Link(string name)
        {
            if (!(Links ?? new LinkCollection()).TryGetValue(name, out var value))
            {
                throw new Exception($"The document does not define a link for '{name}'");
            }

            return value;
        }
    }
}