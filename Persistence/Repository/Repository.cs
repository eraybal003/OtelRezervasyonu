using Domain.CommonClass;
using Persistence.Context;
using Persistence.IRepository;
using System.Linq.Expressions;

namespace Persistence.Repository;

public class Repository<TEntity>(AppDbContext context) : IRepository<TEntity> where TEntity : CommonBase
{
    private readonly AppDbContext _context1 = context;
    public void Add(TEntity entity)
    {
        //entity.Id = Ulid.NewUlid();
        entity.CreatedDate = DateTime.Now;
        _context1.Set<TEntity>().Add(entity);
        _context1.SaveChanges();
    }

    public bool Any(Expression<Func<TEntity, bool>> expression)
    {
        return _context1.Set<TEntity>().Any(expression);
    }

    public void Delete(TEntity entity)
    {
        entity.DeletedDate = DateTime.Now;
        _context1.Set<TEntity>().Remove(entity);
        _context1.SaveChanges();
    }

    public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, bool withDeleted = false)
    {
        return _context1.Set<TEntity>().Where(expression);
    }

    public TEntity? FindOne(Expression<Func<TEntity, bool>> expression)
    {
        return _context1.Set<TEntity>().SingleOrDefault(expression);
    }

    public IQueryable<TEntity> GetAll(bool withDeleted = false)
    {
        if (withDeleted)
        {
            return _context1.Set<TEntity>();
        }
        else
        {
            return _context1.Set<TEntity>().Where(X => X.DeletedDate == null);
        }
    }

    public void Update(TEntity entity)
    {
        entity.UpdatedDate = DateTime.Now;
        _context1.Set<TEntity>().Update(entity);
        _context1.SaveChanges();
    }
}
