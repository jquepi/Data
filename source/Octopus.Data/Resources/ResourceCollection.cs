using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Octopus.Data.Model;

namespace Octopus.Data.Resources
{
    public class ResourceCollection<TResource> : Resource
    {
        public ResourceCollection(IEnumerable<TResource> items, LinkCollection links)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (links == null) throw new ArgumentNullException(nameof(links));
            Items = items.ToList();
            Links = links;
        }

        [JsonProperty(Order = 1)] public string ItemType => typeof(TResource).Name.Replace("Resource", "");

        [JsonProperty(Order = 4)] public int TotalResults { get; set; }

        [JsonProperty(Order = 5)] public int ItemsPerPage { get; set; }

        [JsonProperty(Order = 6)]
        public int NumberOfPages =>
            ItemsPerPage == 0 ? 1 : (int) Math.Max(1, Math.Ceiling((double) TotalResults / ItemsPerPage));

        [JsonProperty(Order = 6)] public int LastPageNumber => NumberOfPages - 1;

        [JsonProperty(Order = 10)] public IList<TResource> Items { get; set; }
    }
}