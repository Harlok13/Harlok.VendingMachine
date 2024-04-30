namespace Harlok.Core.Result;

public abstract class Result<TData>
    where TData: class?
{
    public abstract ResultType ResultType { get; }
    public abstract IReadOnlyCollection<Error> Errors { get; }
    public abstract TData? Data { get; }
    public abstract string? Message { get; }
    
    public bool IsSuccess { get; protected init; }
    
    public bool IsFailure { get; protected init; }

    protected Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
        IsFailure = !isSuccess;
    }
}