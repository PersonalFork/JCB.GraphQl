using Microsoft.EntityFrameworkCore;

namespace Graph.Data.Base
{
    public abstract class BaseDbContext : DbContext
    {
        protected BaseDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}