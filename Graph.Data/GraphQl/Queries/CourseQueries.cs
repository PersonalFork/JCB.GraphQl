using Graph.Data.GraphQl.Types;
using Graph.Data.Repositories;
using GraphQL;
using GraphQL.Types;

namespace Graph.Data.GraphQl.Queries
{
    public class CourseQueries : ObjectGraphType
    {
        public CourseQueries(ICoursesRepository coursesRepository)
        {
            // Field to get the list of courses.
            Field<ListGraphType<CourseType>>("courses")
                .Description("Returns list of courses")
                .Resolve(context => coursesRepository.GetAll());

            // Field to get a course by ID.
            Field<CourseType>("course")
                .Description("Returns a specific course")
                .Argument<GuidGraphType>("Id")
                .Resolve(context => coursesRepository.Get(context.GetArgument("Id", Guid.Empty)));
        }
    }
}