using System.Linq.Expressions;

namespace Graph.Data.Interfaces
{
    public interface IRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        IQueryable<TEntity> GetAll();

        TEntity Get(TId id);

        TId Create(TEntity item);

        int Delete(TId id);

        int Update(TEntity item);

        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
    }
}