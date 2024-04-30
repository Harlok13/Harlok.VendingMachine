using Harlok.Core.Exceptions;
using Harlok.Core.Result;
using Harlok.Core.Result.DomainResult;
using Harlok.Core.Result.ResultImplementation;
using Harlok.VendingMachine.Application.Repositories;
using Harlok.VendingMachine.Contracts.Request;
using Harlok.VendingMachine.Contracts.Response;
using Harlok.VendingMachine.Domain.Contracts;
using Harlok.VendingMachine.Domain.Entities;
using Microsoft.Extensions.Logging;

using static Harlok.VendingMachine.Application.Messages.MessageConstants;
using static Harlok.Core.Messages.MessageConstants;

namespace Harlok.VendingMachine.Application.Services;

public class VendingMachineService : IVendingMachineService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<VendingMachineService> _logger;

    public VendingMachineService(IUnitOfWork unitOfWork, ILogger<VendingMachineService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result<GetAllDrinksResponse>> GetAllDrinksAsync(CancellationToken cT)
    {
        var drinks = await _unitOfWork.DrinkRepository.GetAllDrinksAsNoTrackingAsync(cT);

        if (!drinks.Any())
        {
            return NotFoundResult<GetAllDrinksResponse>
                .Create(new Error(DrinksNotFound));
        }

        return SuccessResult<GetAllDrinksResponse>
            .Create(new GetAllDrinksResponse(drinks));
    }

    public async Task<Result<BuyDrinksResponse>> BuyDrinksAsync(BuyDrinksRequest request, CancellationToken cT)
    {
        try
        {
            _logger.LogInformation(InvokeMethodWithArgs,
                nameof(BuyDrinksAsync), request);
            
            var vendingMachine = await _unitOfWork.VendingMachineRepository
                .GetVendingMachineAsync(request.VendingMachineId, cT);

            DomainResult buyDrinksResult = vendingMachine.BuyDrinks(request.BuyDrinkInfos);
            if (buyDrinksResult.IsFailure)
            {
                _logger.LogWarning(SendInvalidResult,
                    nameof(BuyDrinksResponse), FailedBuyDrink, buyDrinksResult.Message);

                var invalidResult = InvalidResult<BuyDrinksResponse>.Create(
                    error: new Error(FailedBuyDrink),
                    message: buyDrinksResult.Message);

                return invalidResult;
            }
            
            if (buyDrinksResult.Data is not SuccessPurchasedDrinks successPurchasedDrinks)
                throw new CantConvertToTypeException(
                    string.Format(CantConvertToType, nameof(SuccessPurchasedDrinks)));

            _unitOfWork.SetEntityAsModified(vendingMachine);
            
            bool isChanged = await _unitOfWork.SaveChangesAsync(cT);
            if (!isChanged)
                return ServiceUnavailableResult<BuyDrinksResponse>.Create(new Error(DataWasNotSaved));
            
            return SuccessResult<BuyDrinksResponse>.Create(new(
                    Drinks: successPurchasedDrinks.Drinks,
                    OddMoney: successPurchasedDrinks.OddMoney));
        }
        catch (VendingMachineNotFoundException ex)
        {
            _logger.LogError(ExceptionMessage, ex.Message, ex.StackTrace);

            return InvalidResult<BuyDrinksResponse>.Create(new Error(FailedBuyDrink));
        }
        catch (Exception ex)
        {
            _logger.LogError(ExceptionMessage, ex.Message, ex.StackTrace);

            return UnexpectedResult<BuyDrinksResponse>.Create();
        }
    }

    public async Task<Result<DepositCoinResponse>> DepositCoinAsync(DepositCoinRequest request, CancellationToken cT)
    {
        try
        {
            _logger.LogInformation(InvokeMethodWithArgs,
                nameof(DepositCoinAsync), request);

            User user = await _unitOfWork.UserRepository.GetUserAsync(cT);
            var vendingMachine = await _unitOfWork.VendingMachineRepository
                .GetVendingMachineAsync(request.VendingMachineId, cT);

            user.DepositCoinToMachine(request.Coin);
            
                ...
        }
        catch (UserNotFoundException ex)
        {
            _logger.LogWarning(ExceptionMessage, ex.Message, ex.StackTrace);

            return InvalidResult<DepositCoinResponse>.Create(new Error(UserIsNotInitialized));
        }
        catch (VendingMachineNotFoundException ex)
        {
            _logger.LogWarning(ExceptionMessage, ex.Message, ex.StackTrace);
            
            return InvalidResult<DepositCoinResponse>.Create(new Error(VendingMachineNotFound));
        }
        catch (Exception ex)
        {
            _logger.LogError(ExceptionMessage, ex.Message, ex.StackTrace);

            return UnexpectedResult<DepositCoinResponse>.Create();
        }
    }

    public async Task<Result<RollbackCoinsResponse>> RollbackCoinsAsync(RollbackCoinsRequest request, CancellationToken cT)
    {
        try
        {
            _logger.LogInformation(InvokeMethodWithArgs,
                nameof(RollbackCoinsAsync), request);
            
                ...
        }
        catch (UserNotFoundException ex)
        {
            _logger.LogWarning(ExceptionMessage, ex.Message, ex.StackTrace);

            return InvalidResult<RollbackCoinsResponse>.Create(new Error(UserIsNotInitialized));
        }
        catch (VendingMachineNotFoundException ex)
        {
            _logger.LogWarning(ExceptionMessage, ex.Message, ex.StackTrace);
            
            return InvalidResult<RollbackCoinsResponse>.Create(new Error(VendingMachineNotFound));
        }
        catch (Exception ex)
        {
            _logger.LogError(ExceptionMessage, ex.Message, ex.StackTrace);

            return UnexpectedResult<RollbackCoinsResponse>.Create();
        }
    }
}