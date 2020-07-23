using System;
using System.Collections.Generic;
using System.Linq;

namespace Octopus.Data
{
    public interface IFailureResult : IResult
    {
        string[] Errors { get; }
        string ErrorString { get; }
    }

    public class FailureResult : IFailureResult
    {
        public FailureResult(IEnumerable<string> errors)
        {
            Errors = errors.ToArray();
        }
        public string[] Errors { get; }

        public string ErrorString => string.Join(Environment.NewLine, Errors);
    }

    public interface IFailureResult<T> : IFailureResult, IResult<T>
    {
    }

    public class FailureResult<T> : FailureResult, IFailureResult<T>
    {
        public FailureResult(IEnumerable<string> errors) : base(errors)
        {
        }
    }
}