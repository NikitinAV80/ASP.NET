using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.DataAccess.EntityFramework;

namespace PromoCodeFactory.DataAccess.Repositories;

public class EfRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _entitySet;
    protected readonly DbContext Context;

    public EfRepository(DatabaseContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        _entitySet = context.Set<T>();
    }
    #region Get
    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken token = default)
    {
        return await _entitySet.ToListAsync(token);
    }

    public async Task<T> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _entitySet.FindAsync(id, token);
    }
    #endregion Get
}