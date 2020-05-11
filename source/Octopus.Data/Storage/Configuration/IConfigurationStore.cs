using System;
using Octopus.Data.Model.Configuration;

namespace Octopus.Data.Storage.Configuration
{
    public interface IConfigurationStore
    {
        TDocument Get<TDocument>(string id) where TDocument : ConfigurationDocument;

        void Create<TDocument>(TDocument document) where TDocument : ConfigurationDocument;
        void Update<TDocument>(TDocument document) where TDocument : ConfigurationDocument;
        void Delete<TDocument>(TDocument document) where TDocument : ConfigurationDocument;
        void DeleteById<TDocument>(string documentId) where TDocument : ConfigurationDocument;

        void CreateOrUpdate<TDocument>(string id, Action<TDocument> assignPropertiesCallback) where TDocument : ConfigurationDocument, new();
    }
}