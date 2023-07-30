using System;

namespace Discount.API.Models
{
    public class Result
    {
        private Result(bool isSuccess = true, Exception? exception = null)
        {
            IsSuccess = isSuccess;
            Exception = exception;
        }

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public Exception? Exception { get; }

        public static Result Success()
        {
            return new Result();
        }

        public static Result Failure(Exception? ex = null)
        {
            return new Result(false, ex);
        }

        public static Result Define(bool isSuccess, Exception? ex = null)
        {
            return new Result(isSuccess, ex);
        }

        public static bool operator true(Result result) => result.IsSuccess;
        public static bool operator false(Result result) => result.IsFailure;
    }
}
