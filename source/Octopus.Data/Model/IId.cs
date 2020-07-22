using System;

namespace Octopus.Data.Model
{
    public interface IId
    {
        string Id { get; }
    }

    public interface IId<out TId>
        where TId : ITypedId
    {
        TId Id { get; }
    }
}