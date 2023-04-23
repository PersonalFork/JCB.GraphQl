using Graph.Data.Base;
using Graph.Data.Entities;
using Graph.Data.Interfaces;

namespace Graph.Data.Repositories
{
    public interface ICoursesRepository : IRepository<CourseEntity, Guid>
    {
    }

    public class CoursesRepository : BaseRepository<CourseEntity, Guid>, ICoursesRepository
    {
        public CoursesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}