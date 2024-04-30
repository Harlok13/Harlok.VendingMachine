using System.Net;
using Harlok.Core.Result;
using Harlok.VendingMachine.Contracts.Base;
using Microsoft.AspNetCore.Mvc;

using static Harlok.VendingMachine.Messages.MessageConstants;

namespace Harlok.VendingMachine.Extensions;

public static class ControllerExtensions
{
    public static IActionResult FromResult<TResult>(this ControllerBase controller, Result<TResult> result)
        where TResult: class, IApiResult
    {
        switch (result.ResultType)
        {
            case ResultType.Ok:
                return controller.Ok(new ApiResponse<TResult>(
                    StatusCode: HttpStatusCode.OK,
                    Message: result.Message,
                    Result: result.Data));
            
            case ResultType.NotFound:
                return controller.NotFound(new ApiResponse<TResult>(
                    StatusCode: HttpStatusCode.NotFound,
                    Message: result.Message,
                    Errors: result.Errors));
            
            case ResultType.Invalid:
                return controller.BadRequest(new ApiResponse<TResult>(
                    StatusCode: HttpStatusCode.BadRequest,
                    Message: result.Message,
                    Errors: result.Errors));
            
            case ResultType.Unexpected:
                return controller.Unauthorized(new ApiResponse<TResult>(
                    StatusCode: HttpStatusCode.InternalServerError,
                    Message: result.Message,
                    Errors: result.Errors));
            
            case ResultType.ServiceUnavailable:
                return controller.Unauthorized(new ApiResponse<TResult>(
                    StatusCode: HttpStatusCode.ServiceUnavailable,
                    Message: result.Message,
                    Errors: result.Errors));
            
            default:
                throw new Exception(UnregisteredCall);
        }
    }
}