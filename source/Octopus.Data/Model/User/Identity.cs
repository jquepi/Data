using System;
using Nevermore.Contracts;

namespace Octopus.Data.Model.User
{
    public abstract class Identity : IId
    {
        protected Identity()
        {}

        protected Identity(string provider)
        {
            Provider = provider;
        }

        protected Identity(string id, string provider) : this(provider)
        {
            Id = id;
        }

        public string Id { get; }
        public string Provider { get; }
    }
}