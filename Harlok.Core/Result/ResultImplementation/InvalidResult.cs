using System.Collections.ObjectModel;

namespace Harlok.Core.Result.ResultImplementation;

public sealed class InvalidResult<TData> : Result<TData>
    where TData: class?
{
    private InvalidResult(IEnumerable<Error> errors, string? message = null) : base(isSuccess: false)
    {
        Errors = new ReadOnlyCollection<Error>(errors as List<Error> ?? new List<Error>());
        Message = message;
    }

    public override ResultType ResultType => ResultType.Invalid;

    public override IReadOnlyCollection<Error> Errors { get; }

    public override TData? Data => default;
    public override string? Message { get; }

    public static InvalidResult<TData> Create(Error error, string? message = null) => 
        new(new List<Error>(1) { error }, message);

    public static InvalidResult<TData> Create(IEnumerable<Error> errors, string? message = null) => 
        new(errors, message);
}