namespace Harlok.Core.Exceptions;

public sealed class UserNotFoundException : ApplicationException
{
    public UserNotFoundException(string message) : base(message) { }
}