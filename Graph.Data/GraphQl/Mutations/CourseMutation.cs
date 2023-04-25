using Graph.Data.Entities;
using Graph.Data.GraphQl.Types;
using Graph.Data.Repositories;
using Graph.Models;
using GraphQL;
using GraphQL.Types;

namespace Graph.Data.GraphQl.Mutations
{
    public class CourseMutation : ObjectGraphType
    {
        public CourseMutation(ICoursesRepository coursesRepository)
        {
            // Add Course.
            Field<CourseType>("addCourse")
                .Description("Add a new course")
                .Arguments(new QueryArgument<NonNullGraphType<CourseInputType>>
                {
                    Name = "Course",
                    Description = "Course Input Parameter"
                })
                .Resolve(context =>
                {
                    var argument = context.GetArgument<Course>("Course");
                    var courseEntity = new CourseEntity()
                    {
                        Name = argument.Name,
                        Description = argument.Description,
                        Price = argument.Price
                    };
                    var courseId = coursesRepository.Create(courseEntity);
                    courseEntity.Id = courseId;
                    return courseEntity;
                });

            // Delete Course.
            Field<IntGraphType>("deleteCourse")
                .Description("Deletes a course")
                .Arguments(new QueryArgument<NonNullGraphType<GuidGraphType>>
                {
                    Name = "Id",
                    Description = "The Id of the item to be deleted"
                })
            .Resolve(context =>
            {
                var argument = context.GetArgument<Guid>("Id");
                var totalRecordsDeleted = coursesRepository.Delete(argument);
                return totalRecordsDeleted;
            });
        }
    }
}