using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using static Harlok.Core.Messages.MessageConstants;

namespace Harlok.Core.UnitOfWorkFactory;

public abstract class UnitOfWorkFactory<TContext> : IUnitOfWorkFactory
    where TContext : DbContext
{
    protected readonly TContext Context;

    private readonly ILogger<TContext> _logger;

    protected UnitOfWorkFactory(
        TContext context,
        ILogger<TContext> logger)
    {
        Context = context;
        _logger = logger;
    }
    
    public void Dispose() { }
    
    public async ValueTask<bool> SaveChangesAsync(CancellationToken cT = default)
    {
        var result = await Context.SaveChangesAsync(cT) > 0;
        if (result) 
            return result;
        
        _logger.LogWarning(
            "{InvokedMethod} - Saving did not yield any results.",
            nameof(SaveChangesAsync));
            
        return result;

    }

    public void SetEntityAsModified<TEntity>([NotNull] TEntity entity)
    {
        if (entity is null)
            throw new Exception(ModifiedEntityIsNull);
                
        Context.Entry(entity).State = EntityState.Modified;
    }
}