using Graph.Data.Base;

namespace Graph.Data.Entities
{
    public class CourseEntity : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}