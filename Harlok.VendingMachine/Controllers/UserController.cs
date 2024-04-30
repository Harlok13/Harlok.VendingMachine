using Harlok.Core.Result;
using Harlok.VendingMachine.Application.Services;
using Harlok.VendingMachine.Contracts.Request;
using Harlok.VendingMachine.Contracts.Response;
using Harlok.VendingMachine.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Harlok.VendingMachine.Controllers;

[ApiController]
[Route("/api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private ILogger<UserController> _logger;


    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpPost("coin")]
    public async Task<IActionResult> AddCoin([FromBody] AddCoinRequest request, CancellationToken cT)
    {
        Result<AddCoinResponse> responseResult = await _userService.AddCoinAsync(request, cT);

        return this.FromResult(responseResult);
    }

    [HttpDelete("coin/{id:guid}")]
    public async Task<IActionResult> RemoveCoin(Guid id, CancellationToken cT)
    {
        RemoveCoinRequest request = new(id);
        Result<RemoveCoinResponse> responseResult = await _userService.RemoveCoinAsync(request, cT);

        return this.FromResult(responseResult);
    }

    [HttpGet("coins")]
    public async Task<IActionResult> GetCoins(CancellationToken cT)
    {
        Result<GetCoinsResponse> responseResult = await _userService.GetCoinsAsync(cT);

        return this.FromResult(responseResult);
    }

    [HttpPost("coins")]
    public async Task<IActionResult> AddCoins([FromBody] AddCoinsRequest request, CancellationToken cT)
    {
        Result<AddCoinsResponse> responseResult = await _userService.AddCoinsAsync(request, cT);

        return this.FromResult(responseResult);
    }

    [HttpDelete("coins")]
    public async Task<IActionResult> ClearCoins(CancellationToken cT)
    {
        Result<ClearCoinsResponse> responseResult = await _userService.ClearCoinsAsync(cT);

        return this.FromResult(responseResult);
    }
}