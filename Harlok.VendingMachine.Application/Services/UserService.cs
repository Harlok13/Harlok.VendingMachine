using Harlok.Core.Exceptions;
using Harlok.Core.Result;
using Harlok.Core.Result.DomainResult;
using Harlok.Core.Result.ResultImplementation;
using Harlok.VendingMachine.Application.Repositories;
using Harlok.VendingMachine.Contracts.Request;
using Harlok.VendingMachine.Contracts.Response;
using Harlok.VendingMachine.Domain.Entities;
using Harlok.VendingMachine.Domain.Primitives;
using Microsoft.Extensions.Logging;
using static Harlok.VendingMachine.Application.Messages.MessageConstants;

namespace Harlok.VendingMachine.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UserService> _logger;

    public UserService(
        IUnitOfWork unitOfWork,
        ILogger<UserService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result<AddCoinResponse>> AddCoinAsync(AddCoinRequest request, CancellationToken cT)
    {
        try
        {
            _logger.LogInformation(InvokeMethodWithArgs,
                nameof(AddCoinAsync), request);

            User user = await _unitOfWork.UserRepository.GetUserAsync(cT);

            DomainResult addCoinResult = user.AddCoin(request.Coin);
            if (addCoinResult.IsFailure)
            {
                _logger.LogWarning(SendInvalidResult,
                    nameof(AddCoinsAsync), FailedToAddCoin, addCoinResult.Message);

                var invalidResult = InvalidResult<AddCoinResponse>.Create(
                    error: new Error(FailedToAddCoin),
                    message: addCoinResult.Message);

                return invalidResult;
            }
            
            _unitOfWork.SetEntityAsModified(user);

            bool isChanged = await _unitOfWork.SaveChangesAsync(cT);
            if (!isChanged)
                return ServiceUnavailableResult<AddCoinResponse>.Create(new Error(DataWasNotSaved));

            return SuccessResult<AddCoinResponse>.Create(new AddCoinResponse(
                IsSuccess: true,
                Coin: request.Coin));
            
        }
        catch (UserNotFoundException ex)
        {
            _logger.LogWarning(ExceptionMessage, ex.Message, ex.StackTrace);

            return InvalidResult<AddCoinResponse>.Create(new Error(UserIsNotInitialized));
        }
        catch (Exception ex)
        {
            _logger.LogError(ExceptionMessage, ex.Message, ex.StackTrace);

            return UnexpectedResult<AddCoinResponse>.Create();
        }
    }

    public async Task<Result<RemoveCoinResponse>> RemoveCoinAsync(RemoveCoinRequest request, CancellationToken cT)
    {
        try
        {
            _logger.LogInformation(InvokeMethodWithArgs,
                nameof(RemoveCoinAsync), request);

            User user = await _unitOfWork.UserRepository.GetUserAsync(cT);

            DomainResult removeCoinResult = user.RemoveCoin(request.Id);
            if (removeCoinResult.IsFailure)
            {
                _logger.LogWarning(SendInvalidResult,
                    nameof(RemoveCoinAsync), FailedToRemoveCoin, removeCoinResult.Message);

                var invalidResult = InvalidResult<RemoveCoinResponse>.Create(
                    error: new Error(FailedToRemoveCoin),
                    message: removeCoinResult.Message);

                return invalidResult;
            }
            
            _unitOfWork.SetEntityAsModified(user);

            bool isChanged = await _unitOfWork.SaveChangesAsync(cT);
            if (!isChanged)
                return ServiceUnavailableResult<RemoveCoinResponse>.Create(new Error(DataWasNotSaved));

            return SuccessResult<RemoveCoinResponse>.Create(new RemoveCoinResponse(
                    IsSuccess: true,
                    CoinId: request.Id));
        }
        catch (UserNotFoundException ex)
        {
            _logger.LogWarning(ExceptionMessage, ex.Message, ex.StackTrace);

            return InvalidResult<RemoveCoinResponse>.Create(new Error(UserIsNotInitialized));
        }
        catch (Exception ex)
        {
            _logger.LogError(ExceptionMessage, ex.Message, ex.StackTrace);

            return UnexpectedResult<RemoveCoinResponse>.Create();
        }
    }

    public async Task<Result<GetCoinsResponse>> GetCoinsAsync(CancellationToken cT)
    {
        try
        {
            _logger.LogInformation(InvokeMethod,
                nameof(GetCoinsAsync));

            IReadOnlyCollection<Coin> coins = await _unitOfWork.UserRepository.GetCoinsAsNoTrackingAsync(cT);

            return SuccessResult<GetCoinsResponse>.Create(new GetCoinsResponse(coins));
        }
        catch (UserNotFoundException ex)
        {
            _logger.LogWarning(ExceptionMessage, ex.Message, ex.StackTrace);

            return InvalidResult<GetCoinsResponse>.Create(new Error(UserIsNotInitialized));
        }
        catch (Exception ex)
        {
            _logger.LogError(ExceptionMessage, ex.Message, ex.StackTrace);

            return UnexpectedResult<GetCoinsResponse>.Create();
        }
    }

    public async Task<Result<AddCoinsResponse>> AddCoinsAsync(AddCoinsRequest request, CancellationToken cT)
    {
        try
        {
            _logger.LogInformation(InvokeMethodWithArgs,
                nameof(AddCoinsAsync), request);

            User user = await _unitOfWork.UserRepository.GetUserAsync(cT);

            DomainResult addCoinsResult = user.AddCoins(request.Coins);
            if (addCoinsResult.IsFailure)
            {
                _logger.LogWarning(SendInvalidResult,
                    nameof(AddCoinsAsync), FailedToAddCoins, addCoinsResult.Message);

                var invalidResult = InvalidResult<AddCoinsResponse>.Create(
                    error: new Error(FailedToAddCoins),
                    message: addCoinsResult.Message);

                return invalidResult;
            }
            
            _unitOfWork.SetEntityAsModified(user);

            bool isChanged = await _unitOfWork.SaveChangesAsync(cT);
            if (isChanged)
                return ServiceUnavailableResult<AddCoinsResponse>.Create(new Error(DataWasNotSaved));

            return SuccessResult<AddCoinsResponse>.Create(new AddCoinsResponse(
                IsSuccess: true,
                Coins: request.Coins));
        }
        catch (UserNotFoundException ex)
        {
            _logger.LogWarning(ExceptionMessage, ex.Message, ex.StackTrace);

            return InvalidResult<AddCoinsResponse>.Create(new Error(UserIsNotInitialized));
        }
        catch (Exception ex)
        {
            _logger.LogError(ExceptionMessage, ex.Message, ex.StackTrace);

            return UnexpectedResult<AddCoinsResponse>.Create();
        }
    }

    public async Task<Result<ClearCoinsResponse>> ClearCoinsAsync(CancellationToken cT)
    {
        try
        {
            _logger.LogInformation(InvokeMethod, nameof(ClearCoinsAsync));

            User user = await _unitOfWork.UserRepository.GetUserAsync(cT);
            user.ClearAllCoins();

            _unitOfWork.SetEntityAsModified(user);

            bool isChanged = await _unitOfWork.SaveChangesAsync(cT);
            if (!isChanged)
                return ServiceUnavailableResult<ClearCoinsResponse>.Create(new Error(DataWasNotSaved));
            
            return SuccessResult<ClearCoinsResponse>.Create(new ClearCoinsResponse(IsSuccess: true));
        }
        catch (UserNotFoundException ex)
        {
            _logger.LogWarning(ExceptionMessage, ex.Message, ex.StackTrace);

            return InvalidResult<ClearCoinsResponse>.Create(new Error(UserIsNotInitialized));
        }
        catch (Exception ex)
        {
            _logger.LogError(ExceptionMessage, ex.Message, ex.StackTrace);

            return UnexpectedResult<ClearCoinsResponse>.Create();
        }
    }
}