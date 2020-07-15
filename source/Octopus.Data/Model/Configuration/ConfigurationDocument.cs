using System;

namespace Octopus.Data.Model.Configuration
{
    public abstract class ConfigurationDocument : IId
    {
        protected ConfigurationDocument(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}