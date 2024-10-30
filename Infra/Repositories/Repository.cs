using System.Linq.Expressions;
using Domain.Models;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity//, new()
{
    protected readonly FormContext _context;

    public Repository(FormContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate) {
        return await _context.Set<TEntity>()
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();
    }
    // TODO: Validação caso nao exista formulario com esse id, retirar esse !
    public virtual async Task<TEntity> GetById(int id)  {
        return (await _context.Set<TEntity>()
            .FindAsync(id))!;

    }

    public virtual async Task<List<TEntity>> GetAll() {
        return await _context.Set<TEntity>()
            .ToListAsync();
    }

    public virtual async Task Post(TEntity entity) {
        _context.Set<TEntity>()
            .Add(entity);
        await SaveChanges();
    }

    public virtual async Task Update(TEntity entity)
    {
        _context.Set<TEntity>()
            .Update(entity);
        await SaveChanges();
    }

    public virtual async Task Delete(int id)
    {
        /// _context.Set<TEntity>().Remove(new TEntity { Id = id }); (outra forma de fazer)
        _context.Set<TEntity>()
            .Remove(await _context.Set<TEntity>().FindAsync(id));
        await SaveChanges();
    }
 
    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _context?.Dispose();
    }
}