namespace Harlok.VendingMachine.Configurations;

public sealed class CorsConfig
{
    public string PolicyName { get; init; } = null!;
    
    public string[] Origins { get; init; } = null!;
}