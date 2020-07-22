using System;
using System.Collections.Generic;
using System.Linq;

namespace Octopus.Data
{
    public class FailureResult : IResult
    {
        public FailureResult(IEnumerable<string> errors)
        {
            Errors = errors.ToArray();
        }

        public string[] Errors { get; }

        public string ErrorString => string.Join(Environment.NewLine, Errors);
    }

    public class FailureResult<T> : FailureResult, IResult<T>
    {
        public FailureResult(IEnumerable<string> errors) : base(errors)
        {
        }
    }
}