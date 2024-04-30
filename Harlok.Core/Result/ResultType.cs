namespace Harlok.Core.Result;

public enum ResultType : byte
{
    Ok,
    Invalid,
    Unauthorized,
    PartialOk,
    NotFound,
    PermissionDenied,
    Unexpected,
    ServiceUnavailable
}