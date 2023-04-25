using Graph.Data.Entities;
using GraphQL.Types;

namespace Graph.Data.GraphQl.Types
{
    public class CourseType : ObjectGraphType<CourseEntity>
    {
        public CourseType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Course ID.");
            Field(x => x.Description, type: typeof(StringGraphType)).Description("Description");
            Field(x => x.Price, type: typeof(FloatGraphType)).Description("Price");
            Field(x => x.Name, type: typeof(StringGraphType)).Description("Name");
            Field(x => x.CreatedOn, type: typeof(DateTimeGraphType)).Description("Date Created");
            Field(x => x.UpdatedOn, type: typeof(DateTimeGraphType)).Description("Date Updated");
        }
    }
}