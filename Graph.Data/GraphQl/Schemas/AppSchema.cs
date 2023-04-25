using Graph.Data.GraphQl.Queries;
using GraphQL.Types;

namespace Graph.Data.GraphQl.Schemas
{
    public class AppSchema : Schema
    {
        public AppSchema(CourseQueries courseQueries)
        {
            Query = courseQueries;
        }
    }
}