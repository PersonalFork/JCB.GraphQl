using GraphQL.Types;

namespace Graph.Data.GraphQl.Mutations
{
    public class CourseInputType : InputObjectGraphType
    {
        public CourseInputType()
        {
            Name = "CourseInputType";
            Field<StringGraphType>("Description");
            Field<FloatGraphType>("Price");
            Field<StringGraphType>("Name");
        }
    }
}