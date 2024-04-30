using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Harlok.Core.Exceptions;
using Harlok.Core.Messages;
using Harlok.Core.Result.DomainResult;
using Harlok.VendingMachine.Domain.Commands;
using Harlok.VendingMachine.Domain.Contracts;
using Harlok.VendingMachine.Domain.Enums;
using Harlok.VendingMachine.Domain.Exceptions;
using Harlok.VendingMachine.Domain.Primitives;

using static Harlok.VendingMachine.Domain.Messages.MessageConstants;
using static Harlok.Core.Messages.MessageConstants;

namespace Harlok.VendingMachine.Domain.Entities;

public partial class VendingMachine
{
    private record Purchase(decimal Delta, IReadOnlyCollection<PurchasedDrink> PurchasedDrinks);
    
    public DomainResult BuyDrinks(IReadOnlyCollection<BuyDrinkInfo> buyDrinkInfos)
    {
        lock (_locker)
        {
            ImmutableList<Drink> drinks = _drinks
                .Where(d => buyDrinkInfos
                    .Any(i => i.DrinkName == d.Name))
                .ToImmutableList();

            ImmutableList<BuyDrinkCommand> buyDrinkCommands = (
                from drink in drinks 
                let orderDrink = buyDrinkInfos
                    .FirstOrDefault(di => di.DrinkName == drink.Name) 
                select new BuyDrinkCommand(drink, orderDrink))
                .ToImmutableList();

            DomainResult makePurchaseResult = MakePurchase(buyDrinkCommands);
            if (makePurchaseResult.IsFailure)
                return makePurchaseResult;

            if (makePurchaseResult.Data is not Purchase purchase)
                throw new CantConvertToTypeException(
                    string.Format(CantConvertToType, nameof(Purchase)));
            
            IReadOnlyCollection<Coin> oddMoney = ComputeOddMoney(purchase!.Delta);

            DomainResult buyDrinkResult = new DomainResult(
                IsSuccess: true,
                Data: new SuccessPurchasedDrinks(
                    OddMoney: oddMoney,
                    Drinks: purchase.PurchasedDrinks));

            return buyDrinkResult;
        }
    }
    
    private static IReadOnlyCollection<Coin> ComputeOddMoney([NotNull] decimal? delta)
    {
        if (delta is null)
            throw new DeltaIsNullException(DeltaIsNull);
        
        ImmutableList<ECoinDenomination> coins = Enum
            .GetValues(typeof(ECoinDenomination))
            .Cast<ECoinDenomination>()
            .Reverse()
            .ToImmutableList();
        
        List<Coin> result = new();

        foreach (ECoinDenomination denomination in coins)
        {
            while (delta >= (byte)denomination)
            {
                var id = Guid.NewGuid();
                result.Add(new Coin(id, denomination));
                
                delta -= (byte)denomination;
            }
        }
        
        return result.AsReadOnly();
    }

    private DomainResult MakePurchase(IReadOnlyCollection<BuyDrinkCommand> buyDrinkCommands)
    {
        if (!buyDrinkCommands.Any(c => c.IsEnoughDrinks))
            return new DomainResult(
                IsSuccess: false,
                Message: NotEnoughDrinks);

        decimal deposit = _deposit.Sum(c => (byte)c.Denomination);
        decimal cost = buyDrinkCommands.Sum(c => c.Cost);
        if (cost > deposit)
            return new DomainResult(
                IsSuccess: false,
                Message: NoSuchMoneyToByDrinks);

        List<PurchasedDrink> purchasedDrinks = new();
        foreach (var command in buyDrinkCommands)
        {
            DomainResult commandResult = command.Execute();
            if (commandResult.IsFailure)
                return commandResult;

            if (commandResult.Data is not PurchasedDrink pDrink)
                throw new CantConvertToTypeException(
                    string.Format(MessageConstants.CantConvertToType, nameof(PurchasedDrink)));
            
            purchasedDrinks.Add(pDrink);
        }

        AddEarnedMoney(cost);

        decimal delta = deposit - cost;
        DomainResult makePurchaseResult = new(
            IsSuccess: true,
            Data: new Purchase(
                Delta: delta, 
                PurchasedDrinks: purchasedDrinks));

        return makePurchaseResult;
    }
}