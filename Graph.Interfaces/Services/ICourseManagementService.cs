using Graph.Models;

namespace Graph.Interfaces.Services
{
    public interface ICourseManagementService
    {
        public IEnumerable<Course> GetAll();

        public Course? GetById(Guid id);

        public Guid Add(Course course);

        public int Remove(string id);

        public int Update(Course course);
    }
}