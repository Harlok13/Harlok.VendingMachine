namespace Harlok.VendingMachine.Domain.Messages;

public static class MessageConstants
{
    /* -------------------------- Results -------------------------- */
    // User
    public const string CantAddExistingCoin = "It is impossible to add a coin with an existing ID.";
    public const string CantAddIncorrectDenominationCoin = "It is impossible to add a coin with an incorrect denomination.";
    public const string CantAddCoinsWithSameIds = "It is impossible to add coins with the same ID.";
    public const string CoinNotFound = "Coin with ID '{0}' not found.";
    
    // VendingMachine
    public const string NotEnoughDrinks = "There are not enough drinks in the vending machine.;";
    public const string NoSuchMoneyToByDrinks = "Not enough money to purchase selected drinks.";

    /* -------------------------- Exceptions ----------------------- */
    public const string DeltaIsNull = "The difference between the deposit and the amount spent is null.";
}