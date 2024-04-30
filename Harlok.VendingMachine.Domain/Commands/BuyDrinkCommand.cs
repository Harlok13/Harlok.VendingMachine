using Harlok.Core.Result.DomainResult;
using Harlok.VendingMachine.Domain.Entities;
using Harlok.VendingMachine.Domain.Primitives;

namespace Harlok.VendingMachine.Domain.Commands;

public class BuyDrinkCommand
{
    private readonly Drink _drink;
    private readonly BuyDrinkInfo _orderDrink;
    
    public BuyDrinkCommand(Drink drink, BuyDrinkInfo orderDrink)
    {
        _drink = drink;
        _orderDrink = orderDrink;
    }
    
    public decimal Cost => _drink.GetTotalCost(_orderDrink);

    public bool IsEnoughDrinks => _drink.CheckDrinksAmount(_orderDrink);

    public DomainResult Execute() => _drink.MakePurchase(_orderDrink);
}