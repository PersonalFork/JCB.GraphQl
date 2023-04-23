using Graph.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Graph.Data.Base
{
    public abstract class BaseRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _entities;

        protected BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<TEntity>();
        }

        public TId Create(TEntity item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            _entities.Add(item);
            _dbContext.SaveChanges();
            return item.Id;
        }

        public int Delete(TId id)
        {
            var entity = _entities.FirstOrDefault(X => X.Id.Equals(id));
            if (entity == null)
            {
                return 0;
            }

            _entities.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public TEntity Get(TId id)
        {
            return _entities.FirstOrDefault(x => x.Id.Equals(id));
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entities.AsQueryable();
        }

        public int Update(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var existingItem = _entities.FirstOrDefault(x => x.Id.Equals(item.Id));
            if (existingItem == null)
            {
                return 0;
            }
            _entities.Update(item);
            return _dbContext.SaveChanges();
        }

        public IQueryable<TEntity> Filter(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }
    }
}