using System;
using System.Collections.Generic;
using System.Linq;

namespace Octopus.Data
{
    public static class ResultExtensionMethods
    {
        public static IResult Then<TIn, TOut>(
            this IReadOnlyCollection<IResult> results,
            Func<IEnumerable<TIn>, TOut> ifAllSuccessful
        )
        {
            var successResults = results.OfType<Result<TIn>>().ToArray();
            if (successResults.Length == results.Count)
                return Result<TOut>.Success(ifAllSuccessful(successResults.Select(r => r.Value)));

            return Result.Failed(results.OfType<FailureResult>().ToArray());
        }

        public static IResult Then<TIn, TOut>(
            this IResult result,
            Func<TIn, Result<TOut>> ifSuccessful
        )
        {
            return result is Result<TIn> successResult ? (IResult)ifSuccessful(successResult.Value) : Result.Failed((FailureResult)result);
        }

        public static IResult Then<TIn, TOut>(
            this IResult result,
            Func<TIn, TOut> ifSuccessful
        )
        {
            return result is Result<TIn> successResult ? (IResult)Result<TOut>.Success(ifSuccessful(successResult.Value)) : Result.Failed((FailureResult)result);
        }

        public static Result<TOut> Combine<TA, TB, TOut>(this Result<TA> a, Result<TB> b, Func<TA, TB, TOut> transform)
        {
            return transform(a.Value, b.Value)!;
        }

        public static IResult If<T>(this Result<T> a, IResult b)
        {
            if (b is FailureResult fail)
                return Result.Failed(fail);
            return a;
        }

        public static IResult If<T>(this IResult a, Result<T> b)
        {
            if (a is FailureResult fail)
                return Result.Failed(fail);
            return b;
        }

        public static Result<T> AsSuccessResult<T>(this T value)
        {
            return Result<T>.Success(value);
        }
    }
}