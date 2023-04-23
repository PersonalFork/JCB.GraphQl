using Microsoft.EntityFrameworkCore;

namespace Graph.Data.Base
{
    public abstract class BaseDbContext : DbContext
    {
        protected readonly bool _created;

        protected BaseDbContext(DbContextOptions options) : base(options)
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }
    }
}