using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
namespace PromoCodeFactory.DataAccess.Repositories;

public class InMemoryRepository<T>: IRepository<T> where T: BaseEntity
{
    protected List<T> Data { get; set; }

    public InMemoryRepository(IEnumerable<T> data)
    {
        Data = data.ToList();
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return Task.FromResult(Data.AsEnumerable());
    }

    public Task<T> GetByIdAsync(Guid id)
    {
        return Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
    }

    public Task<Guid> CreateAsync(T entity)
    {
        entity.Id = Guid.NewGuid();
        Data.Add(entity);
            
        return Task.FromResult(entity.Id);
    }

    public Task UpdateAsync(Guid id, T entity)
    {
        var index = Data.FindIndex(x => x.Id == id);
        Data[index] = entity;
            
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var index = Data.FindIndex(x => x.Id == id);
        Data.RemoveAt(index);
            
        return Task.CompletedTask;
    }
}