namespace Harlok.Core.Exceptions;

public sealed class CantConvertToTypeException : ApplicationException
{
    public CantConvertToTypeException(string message) : base(message) { }
}