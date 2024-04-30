using Harlok.Core.Result;
using Harlok.VendingMachine.Application.Services;
using Harlok.VendingMachine.Contracts.Request;
using Harlok.VendingMachine.Contracts.Response;
using Harlok.VendingMachine.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Harlok.VendingMachine.Controllers;

[ApiController]
[Route("/api/vending_machine")]
public class VendingMachineController : ControllerBase
{
    private readonly ILogger<VendingMachineController> _logger;
    private readonly IVendingMachineService _vendingMachineService;

    public VendingMachineController(
        ILogger<VendingMachineController> logger,
        IVendingMachineService vendingMachineService)
    {
        _logger = logger;
        _vendingMachineService = vendingMachineService;
    }

    [HttpGet("drinks")]
    public async Task<IActionResult> GetAllDrinks(CancellationToken cT)
    {
        Result<GetAllDrinksResponse> responseResult = await _vendingMachineService.GetAllDrinksAsync(cT);

        return this.FromResult(responseResult);
    }

    [HttpPost("drinks")]
    public async Task<IActionResult> BuyDrinks(BuyDrinksRequest request, CancellationToken cT)
    {
        Result<BuyDrinksResponse> responseResult = await _vendingMachineService.BuyDrinksAsync(request, cT);

        return this.FromResult(responseResult);
    }

    [HttpPost("coin")]
    public async Task<IActionResult> DepositCoin(DepositCoinRequest request, CancellationToken cT)
    {
        Result<DepositCoinResponse> responseResult = await _vendingMachineService.DepositCoinAsync(request, cT);

        return this.FromResult(responseResult);
    }

    [HttpDelete("coins")]
    public async Task<IActionResult> RollbackCoins(RollbackCoinsRequest request, CancellationToken cT)
    {
        Result<RollbackCoinsResponse> responseResult = await _vendingMachineService.RollbackCoinsAsync(request, cT);

        return this.FromResult(responseResult);
    }
}