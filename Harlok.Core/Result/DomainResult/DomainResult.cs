namespace Harlok.Core.Result.DomainResult;

public record DomainResult(
    bool IsSuccess,
    string? Message = null,
    object? Data = null) : DomainResultBase(!IsSuccess);