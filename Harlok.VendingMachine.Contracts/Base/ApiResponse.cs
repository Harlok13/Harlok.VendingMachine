using System.Net;
using Harlok.Core.Result;

namespace Harlok.VendingMachine.Contracts.Base;

public record ApiResponse<TResult>(  // TODO: reloc to core
    HttpStatusCode StatusCode,
    string? Message = null,
    TResult? Result = null,
    IReadOnlyCollection<Error>? Errors = null)
    where TResult : class, IApiResult;