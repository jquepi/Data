using System;
using System.Collections.Generic;
using System.Linq;

namespace Octopus.Data
{
    public interface IResult
    {
        bool WasSuccessful { get; }
        string[] Errors { get; }
        string ErrorString { get; }
        bool WasFailure { get; }
    }

    public class Result : IResult
    {
        private string[] errors = Array.Empty<string>();

        protected Result()
        {
        }

        public bool WasSuccessful { get; private set; }
        public bool WasFailure => !WasSuccessful;

        public string[] Errors => errors.ToArray();

        public string ErrorString => string.Join(Environment.NewLine, errors);


        public static Result Failed(params string[] errors)
        {
            return new Result { errors = errors.ToArray() };
        }
        public static Result Failed(IReadOnlyList<string> errors)
        {
            return new Result { errors = errors.ToArray() };
        }

        public static Result Failed(params IResult[] becauseOf)
        {
            return new Result { errors = becauseOf.SelectMany(b => b.Errors).ToArray() };
        }

        public static Result Success()
        {
            return new Result { WasSuccessful = true };
        }

        public static Result From(params Result[] results)
        {
            var failed = results.Where(r => !r.WasSuccessful).ToArray();
            if (failed.Length == 0)
                return Result.Success();
            return Result.Failed(failed.SelectMany(f => f.Errors).ToArray());
        }
    }

#nullable disable
    public class Result<T> : IResult
    {
        private T value;
        private string[] errors = Array.Empty<string>();

        protected Result()
        {
        }

        public bool WasSuccessful { get; private set; }

        public string[] Errors => errors.ToArray();

        public string ErrorString => errors != null && errors.Any() ? string.Join(Environment.NewLine, errors) : string.Empty;

        public T Value
        {
            get
            {
                if (!WasSuccessful)
                    throw new Exception("No value as the operation was not successful");
                return value;
            }
        }

        public bool WasFailure => !WasSuccessful;

        public static Result<T> Failed()
        {
            return new Result<T>() { errors = new string[0] };
        }

        public static Result<T> Failed(params string[] errors)
        {
            return new Result<T>() { errors = errors.ToArray() };
        }

        public static Result<T> Failed(params IResult[] becauseOf)
        {
            return new Result<T>() { errors = becauseOf.Where(s => s.WasFailure).SelectMany(b => b.Errors).ToArray() };
        }

        public static Result<T> Failed(IReadOnlyCollection<IResult> becauseOf)
        {
            return new Result<T>() { errors = becauseOf.Where(s => s.WasFailure).SelectMany(b => b.Errors).ToArray() };
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>() { WasSuccessful = true, value = value };
        }

        public static implicit operator Result<T>(T value)
        {
            return Success(value);
        }

        public static implicit operator T(Result<T> result)
        {
            return result.Value;
        }

        public T ValueOr(T def)
        {
            return WasSuccessful ? Value : def;
        }

        public override string ToString()
        {
            return WasSuccessful
                ? "" + Value
                : ErrorString;
        }

        public static Result<T> From<TIn>(Result<TIn> result) where TIn : T
        {
            return result.WasSuccessful
                ? Success(result.Value)
                : Failed(result);
        }
    }
#nullable enable
}