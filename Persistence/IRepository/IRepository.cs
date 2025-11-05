using Domain.CommonClass;
using System.Linq.Expressions;

namespace Persistence.IRepository;

public interface IRepository<TEntity> where TEntity : CommonBase
{
    IQueryable<TEntity> GetAll(bool withDeleted = false);
    TEntity? FindOne(Expression<Func<TEntity, bool>> expression);
    IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, bool withDeleted = false);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    bool Any(Expression<Func<TEntity,bool>> expression);

}
