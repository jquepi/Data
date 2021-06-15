using System;

namespace Octopus.Data.Model
{
    public interface IDocument : IDocument<string>, IId
    {
    }

    public interface IDocument<out TId> : IId<TId>, INamed
    {
    }
}