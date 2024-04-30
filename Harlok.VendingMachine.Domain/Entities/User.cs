using Harlok.Core.Result.DomainResult;
using Harlok.VendingMachine.Domain.Enums;
using Harlok.VendingMachine.Domain.Primitives;

using static Harlok.VendingMachine.Domain.Messages.MessageConstants;

namespace Harlok.VendingMachine.Domain.Entities;

public sealed class User
{
    private List<Coin> _coins;
    
    private readonly object _locker = new();

    private User(Guid id)
    {
        Id = id;
        _coins ??= new();
    }

    public Guid Id { get; init; }
    public IReadOnlyCollection<Coin> Coins
    {
        get
        {
            lock (_locker)
            {
                return _coins.AsReadOnly();
            }
        }
    }

    public static User Create(Guid id, List<Coin> coins) => 
        new(id) { _coins = coins };

    public DomainResult AddCoin(Coin coin)
    {
        lock (_locker)
        {
            if (_coins.Any(c => c.Id == coin.Id)) 
                return new DomainResult(
                    IsSuccess: false,
                    Message: CantAddExistingCoin);

            if (!Enum.IsDefined(typeof(ECoinDenomination), coin.Denomination))
                return new DomainResult(
                    IsSuccess: false,
                    Message: CantAddIncorrectDenominationCoin);
            
            _coins.Add(coin);
        }
        
        return new DomainResult(IsSuccess: true);
    }

    public void ClearAllCoins()
    {
        lock (_locker)
        {
            _coins.Clear();
        }
    }
    
    public DomainResult AddCoins(IReadOnlyCollection<Coin> coins)
    {
        lock(_locker)
        {
            if (coins.Any(c => !Enum.IsDefined(typeof(ECoinDenomination), c.Denomination)))
                return new DomainResult(
                    IsSuccess: false,
                    Message: CantAddIncorrectDenominationCoin);
            
            if (coins.GroupBy(c => c.Id).Any(g => g.Count() > 1))
                return new DomainResult(
                    IsSuccess: false,
                    Message: CantAddCoinsWithSameIds);
                    
            if (_coins.Any(c => coins.Any(cc => cc.Id == c.Id)))
                return new DomainResult(
                    IsSuccess: false,
                    Message: CantAddExistingCoin);
            
            _coins.AddRange(coins);

            return new DomainResult(IsSuccess: true);
        }
    }
    
    public DomainResult RemoveCoin(Guid id)
    {
        lock (_locker)
        {
            int index = _coins.FindIndex(c => c.Id == id);
            if (index < 0)
                return new DomainResult(
                    IsSuccess: false,
                    Message: string.Format(CoinNotFound, id));
                
            _coins.RemoveAt(index);

            return new DomainResult(IsSuccess: true);
        }
    }
}