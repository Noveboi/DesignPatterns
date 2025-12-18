namespace DesignPatterns.Domain.Results;

public static class ResultExtensions
{
    extension(Result)
    {
        public static Result Invalid(string errorMessage)
        {
            return Result.Fail(new Invalid(errorMessage));
        }

        public static Result<T> Invalid<T>(string errorMessage)
        {
            return Result.Fail<T>(new Invalid(errorMessage));
        }

        public static Result<T> NotFound<T>()
        {
            return Result.Fail(new NotFound(typeof(T)));
        } 
    }
}