using Harlok.Core.Result.DomainResult;
using Harlok.VendingMachine.Domain.Contracts;
using Harlok.VendingMachine.Domain.Primitives;

using static Harlok.VendingMachine.Domain.Messages.MessageConstants;

namespace Harlok.VendingMachine.Domain.Entities;

public sealed class Drink
{
    private Drink(long id, string name, decimal price, string pictureUrl, short amount, long vendingMachineId)
    {
        Id = id;
        Name = name;
        Price = price;
        PictureUrl = pictureUrl;
        Amount = amount;
        VendingMachineId = vendingMachineId;
    }
    
    public long Id { get; init; }
    
    public string Name { get; private set; } = null!;

    public decimal Price { get; private set; }

    public string PictureUrl { get; private set; } = null!;

    public short Amount { get; private set; }
    
    public VendingMachine VendingMachine { get; init; }
    
    public long VendingMachineId { get; init; }

    public static Drink Create(
        long id, string name, decimal price, string pictureUrl, short amount, long vendingMachineId)
    {
        Drink drink = new(
            id: id,
            name: name, 
            price: price, 
            pictureUrl: pictureUrl, 
            amount: amount, 
            vendingMachineId: vendingMachineId);

        return drink;
    }
    
    internal decimal GetTotalCost(BuyDrinkInfo orderDrink) =>
        orderDrink.Amount * Price;

    internal bool CheckDrinksAmount(BuyDrinkInfo orderDrink) =>
        orderDrink.Amount <= Amount;

    internal DomainResult MakePurchase(BuyDrinkInfo orderDrink)
    {
        DomainResult reduceResult = ReduceAmount(orderDrink.Amount);
        if (reduceResult.IsFailure)
            return reduceResult;

        DomainResult purchaseResult = new(
            IsSuccess: true,
            Data: new PurchasedDrink(
                Name = orderDrink.DrinkName,
                Amount: orderDrink.Amount));

        return purchaseResult;
    }
    
    private DomainResult ReduceAmount(short amount)
    {
        if (amount > Amount)  
            return new DomainResult(
                IsSuccess: false,
                Message: NotEnoughDrinks);

        Amount -= amount;
        if (Amount == 0)
        {
            // TODO: add a domain event notifying the admin that the drink has run out
        }

        return new DomainResult(IsSuccess: true);
    }
}