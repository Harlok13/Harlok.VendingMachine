namespace Harlok.Core.Result.ResultImplementation;

public sealed class ServiceUnavailableResult<TData> : Result<TData>
    where TData: class
{
    private ServiceUnavailableResult(IEnumerable<Error> errors, string? message = null) : base(isSuccess: false)
    {
        Message = message;
        Errors = (errors as IReadOnlyCollection<Error>)!;
    }

    public override ResultType ResultType => ResultType.ServiceUnavailable;

    public override IReadOnlyCollection<Error> Errors { get; }

    public override TData? Data => default;
    public override string? Message { get; }

    public static ServiceUnavailableResult<TData>  Create(Error error, string? message = null) => 
        new(new List<Error>(1) { error }, message);

    public static ServiceUnavailableResult<TData> Create(IEnumerable<Error> errors, string? message = null) => 
        new(errors, message);
}