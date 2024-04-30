namespace Harlok.Core.Result.ResultImplementation;

public sealed class NotFoundResult<TData> : Result<TData>
    where TData: class
{
    private NotFoundResult(IEnumerable<Error> errors, string? message = null) : base(isSuccess: false)
    {
        Message = message;
        Errors = (errors as IReadOnlyCollection<Error>)!;
    }

    public override ResultType ResultType => ResultType.NotFound;

    public override IReadOnlyCollection<Error> Errors { get; }
    
    public override TData? Data => default;
    public override string? Message { get; }

    public static NotFoundResult<TData> Create(Error error, string? message = null) => 
        new(new List<Error>(1) { error }, message);

    public static NotFoundResult<TData> Create(IEnumerable<Error> errors, string? message = null) => 
        new(errors, message);
}