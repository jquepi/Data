using System;
using Nevermore.Contracts;

namespace Octopus.Data.Model.User
{
    public abstract class Identity : IId
    {
        protected Identity()
        {}

        protected Identity(string id, string provider)
        {
            Id = id;
            Provider = provider;
        }

        public string Id { get; }
        public string Provider { get; }
    }
}