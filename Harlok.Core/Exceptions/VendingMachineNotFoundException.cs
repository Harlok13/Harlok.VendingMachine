namespace Harlok.Core.Exceptions;

public sealed class VendingMachineNotFoundException : ApplicationException
{
    public VendingMachineNotFoundException(string message) : base(message) { }
}