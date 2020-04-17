using System;
using Octopus.Data.Model;

namespace Octopus.Data.Storage.Configuration
{
    public interface IConfigurationStore
    {
        TDocument Get<TDocument>(string id) where TDocument : class;

        void Create<TDocument>(TDocument document) where TDocument : class;
        void Update<TDocument>(TDocument document) where TDocument : class;
        void Delete<TDocument>(TDocument document) where TDocument : class;
        void DeleteById<TDocument>(string documentId) where TDocument : class;

        void CreateOrUpdate<TDocument>(string id, Action<TDocument> assignPropertiesCallback) where TDocument : class, IOverridableId, new();
    }
}