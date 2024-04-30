using Harlok.Core.Abstracts;
using Harlok.VendingMachine.Domain.Primitives;


namespace Harlok.VendingMachine.Domain.Entities;

public sealed partial class VendingMachine : AggregateRoot
{
    private readonly List<Drink> _drinks;
    private List<Coin> _deposit;
    
    private readonly object _locker = new();

    private VendingMachine(long id)
    {
        Id = id;
        _drinks ??= new();
        _deposit ??= new();
    }

    public long Id { get; init; }

    public IReadOnlyCollection<Coin> Deposit => _deposit;

    public decimal EarnedMoney { get; private set; }

    public IReadOnlyCollection<Drink> Drinks
    {
        get
        {
            lock (_locker)
            {
                return _drinks.AsReadOnly();
            }
        }
    }

    public static VendingMachine Create(long id)
    {
        return new VendingMachine(id);
    }

    private void AddEarnedMoney(decimal value) => EarnedMoney += value;
}