using Graph.Data.Entities;
using Graph.Data.Repositories;
using Graph.Interfaces.Services;
using Graph.Models;

namespace Graph.Services
{
    public class CourseManagementService : ICourseManagementService
    {
        private readonly ICoursesRepository _coursesRepository;

        public CourseManagementService(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public Guid Add(Course course)
        {
            CourseEntity courseEntity = new()
            {
                Price = course.Price,
                Description = course.Description,
                Name = course.Name
            };

            var id = _coursesRepository.Create(courseEntity);
            return id;
        }

        public IEnumerable<Course> GetAll()
        {
            return _coursesRepository.GetAll().Select(x => new Course()
            {
                Description = x.Description,
                Name = x.Name,
                Id = x.Id.ToString(),
                Price = x.Price
            });
        }

        public Course? GetById(Guid id)
        {
            var course = _coursesRepository.Get(id);
            if (course == null)
            {
                return null;
            }

            return new Course()
            {
                Description = course.Description,
                Id = course.Id.ToString(),
                Name = course.Name,
                Price = course.Price
            };
        }

        public int Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            Guid courseId = new(id);
            return _coursesRepository.Delete(courseId);
        }

        public int Update(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            CourseEntity courseEntity = new()
            {
                Id = new Guid(course.Id),
                Price = course.Price,
                Description = course.Description,
                Name = course.Name
            };

            return _coursesRepository.Update(courseEntity);
        }
    }
}