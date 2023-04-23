using Graph.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace Graph.Data
{
    public class ApplicationDbContext : BaseDbContext
    {
        private DbSet<CourseEntity> Courses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}