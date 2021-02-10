using System;
using Octopus.TinyTypes;

namespace Octopus.Data.Model
{
    public interface IId
    {
        string Id { get; }
    }

    public interface IId<out TId>
        where TId : CaseInsensitiveStringTinyType
    {
        TId Id { get; }
    }
}