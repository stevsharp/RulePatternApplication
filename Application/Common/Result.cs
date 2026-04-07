namespace Infrastructure;

public class Result(bool isSuccess, string? error)
{
    public bool IsSuccess { get; } = isSuccess;
    public string? Error { get; } = error;
    public bool IsFailure => !IsSuccess;
    public static Result Success() => new(true, null);
    public static Result Failure(string error) => new(false, error);

    public static Result Failure(IEnumerable<string> errors) =>
        new(false, string.Join("; ", errors));
}

public sealed class Result<T>(bool isSuccess, T? value, string? error) : Result(isSuccess, error)
{
    public T? Value { get; } = value;

    public static Result<T> Success(T value) => new(true, value, null);
    public new static Result<T> Failure(string error) => new(false, default, error);
}
