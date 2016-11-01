using System;
using Nevermore.Contracts;
using Octopus.Data.Model;

namespace Octopus.Data.Storage.Configuration
{
    public interface IConfigurationStore
    {
        TDocument Get<TDocument>(string id) where TDocument : class, IId;

        void Create<TDocument>(TDocument document) where TDocument : class, IId;
        void Update<TDocument>(TDocument document) where TDocument : class, IId;

        void CreateOrUpdate<TDocument>(string id, Action<TDocument> assignPropertiesCallback) where TDocument : class, IOverridableId, new();
    }
}