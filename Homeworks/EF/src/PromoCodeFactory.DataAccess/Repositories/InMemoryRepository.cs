using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;

namespace PromoCodeFactory.DataAccess.Repositories;

public class InMemoryRepository<T> : IRepository<T>
    where T : BaseEntity
{
    protected List<T> Data { get; set; }

    public InMemoryRepository(IEnumerable<T> data)
    {
        Data = data.ToList();
    }

    public Task<IEnumerable<T>> GetAllAsync(CancellationToken token = default)
    {
        return Task.FromResult(Data.AsEnumerable());
    }

    public Task<T> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
    }

    public Task<Guid> CreateAsync(T entity, CancellationToken token = default)
    {
        entity.Id = Guid.NewGuid();
        Data.Add(entity);
            
        return Task.FromResult(entity.Id);
    }

    public Task UpdateAsync(T entity, CancellationToken token = default)
    {
        var index = Data.FindIndex(x => x.Id == entity.Id);
        Data[index] = entity;
            
        return Task.CompletedTask;
    }

    public Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
    {
        var index = Data.FindIndex(x => x.Id == id);
        Data.RemoveAt(index);
            
        return Task.FromResult(true);
    }
}