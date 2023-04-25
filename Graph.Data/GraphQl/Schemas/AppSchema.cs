using Graph.Data.GraphQl.Mutations;
using Graph.Data.GraphQl.Queries;
using GraphQL.Types;

namespace Graph.Data.GraphQl.Schemas
{
    public class AppSchema : Schema
    {
        public AppSchema(CourseQueries courseQueries, CourseMutation courseMutation)
        {
            Query = courseQueries;
            Mutation = courseMutation;
        }
    }
}