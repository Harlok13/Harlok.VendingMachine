namespace Harlok.VendingMachine.Domain.Exceptions;

public sealed class DeltaIsNullException : ApplicationException
{
    public DeltaIsNullException(string message) : base(message) { }
}