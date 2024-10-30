using System.Linq.Expressions;
using Domain.Models;

namespace Infra.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> GetById(int id);
    Task<List<TEntity>> GetAll();
    Task Post(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(int id);
    Task<int> SaveChanges();
}