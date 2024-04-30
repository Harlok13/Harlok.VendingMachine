using System.Collections.ObjectModel;

namespace Harlok.Core.Result.ResultImplementation;

public sealed class SuccessResult<TData> : Result<TData>
    where TData: class?
{
    private SuccessResult(TData data, string? message = null) : base(isSuccess: true)
    {
        Message = message;
        Data = data;
    }

    public override ResultType ResultType => ResultType.Ok;

    public override IReadOnlyCollection<Error> Errors => 
        new ReadOnlyCollection<Error>(new List<Error>());

    public override TData Data { get; }
    public override string? Message { get; }

    public static SuccessResult<TData> Create(TData data, string? message = null) => 
        new(data, message);
}
