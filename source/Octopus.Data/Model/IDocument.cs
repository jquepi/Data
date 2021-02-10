using System;
using Octopus.TinyTypes;

namespace Octopus.Data.Model
{
    public interface IDocument : IId, INamed
    {
    }

    public interface IDocument<out TId> : IId<TId>, INamed
        where TId : CaseInsensitiveStringTinyType
    {
    }
}