namespace Harlok.Core.UnitOfWorkFactory;

public interface IUnitOfWorkFactory : IDisposable
{
    ValueTask<bool> SaveChangesAsync(CancellationToken cT = default);

    void SetEntityAsModified<TEntity>(TEntity entity);
}