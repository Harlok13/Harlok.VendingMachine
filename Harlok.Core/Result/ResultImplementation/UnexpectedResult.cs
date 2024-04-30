using System.Collections.ObjectModel;

using static Harlok.Core.Messages.MessageConstants;

namespace Harlok.Core.Result.ResultImplementation;

public sealed class UnexpectedResult<TData> : Result<TData>
    where TData: class
{
    private UnexpectedResult(string? message = null) : base(isSuccess: false)
    {
        Message = message;
        Errors = new ReadOnlyCollection<Error>(
            new List<Error>(1) { new(UnexpectedProblem) });
    }

    public override ResultType ResultType => ResultType.Unexpected;

    public override IReadOnlyCollection<Error> Errors { get; }

    public override TData? Data => default;
    public override string? Message { get; }

    public static UnexpectedResult<TData> Create(string? message = null) => new(message);
}