using Microsoft.EntityFrameworkCore;

namespace Graph.Api.Data.Base
{
    public abstract class BaseDbContext : DbContext
    {
        protected BaseDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
