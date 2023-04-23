using Graph.Api.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace Graph.Api.Data
{
    public class ApplicationDbContext : BaseDbContext
    {
        private DbSet<Course> Courses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}