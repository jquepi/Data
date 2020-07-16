using System;
using System.Collections.Generic;
using System.Linq;

namespace Octopus.Data
{
    public interface IResult
    {}

    public class Result : IResult
    {
        public static FailureResult Failed(params string[] errors)
        {
            return new FailureResult(errors);
        }

        public static FailureResult Failed(IReadOnlyList<string> errors)
        {
            return new FailureResult(errors);
        }

        public static FailureResult Failed(params FailureResult[] becauseOf)
        {
            return new FailureResult(becauseOf.SelectMany(b => b.Errors));
        }

        public static Result Success()
        {
            return new Result();
        }

        public static IResult From(params IResult[] results)
        {
            var failed = results.OfType<FailureResult>().ToArray();
            if (failed.Length == 0)
                return Success();
            return Failed(failed.SelectMany(f => f.Errors).ToArray());
        }
    }

    public interface IResult<T> : IResult
    {}

    public interface ISuccessResult<T> : IResult<T>
    {
        T Value { get; }
    }

    public class Result<T> : ISuccessResult<T>
    {
        protected Result(T value)
        {
            Value = value;
        }

        public T Value { get; }

        public static FailureResult<T> Failed(params string[] errors)
        {
            return new FailureResult<T>(errors);
        }

        public static FailureResult<T> Failed(IReadOnlyList<string> errors)
        {
            return new FailureResult<T>(errors);
        }

        public static FailureResult<T> Failed(params FailureResult<T>[] becauseOf)
        {
            return new FailureResult<T>(becauseOf.SelectMany(b => b.Errors));
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(value);
        }

        public static implicit operator Result<T>(T value)
        {
            return Success(value);
        }

        public static implicit operator T(Result<T> result)
        {
            return result.Value;
        }

        public override string ToString()
        {
            return Value?.ToString() ?? string.Empty;
        }
    }
}