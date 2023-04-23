namespace Graph.Api.Data
{
    public class Course : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}