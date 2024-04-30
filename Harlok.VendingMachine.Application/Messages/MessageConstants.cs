namespace Harlok.VendingMachine.Application.Messages;

public static class MessageConstants
{
    public const string DrinksNotFound = "No drinks were found.";
    public const string FailedToRemoveCoin = "Failed to remove coin.";
    public const string FailedToAddCoin = "Failed to add coin.";
    public const string FailedToAddCoins = "Failed to add coins.";
    public const string FailedToClearCoins = "Failed to clear coins.";
    public const string FailedBuyDrink = "Drink purchase failed.";
    public const string DataWasNotSaved = "For some reason the data was not saved.";
    
    public const string InvokeMethodWithArgs = "Invoke method '{@InvokedMethod}' with args: {@Args}";
    public const string InvokeMethod = "Invoke method '{@InvokedMethod}'.";
    public const string SendInvalidResult = "{@InvokedMethod} - Send InvalidResult. Reason: {@Reason}\n{@Message}";

    public const string ExceptionMessage = "{@Message}\n{@StackTrace}";

    public const string UserIsNotInitialized = "User is not initialized.";
    public const string VendingMachineNotFound = "Vending machine was not found.";
}