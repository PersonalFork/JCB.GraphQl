using Graph.Data;
using Graph.Data.GraphQl.Queries;
using Graph.Data.GraphQl.Schemas;
using Graph.Data.Repositories;
using Graph.Interfaces.Services;
using Graph.Services;
using GraphQL;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Services.
builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
builder.Services.AddScoped<ICourseManagementService, CourseManagementService>();

var sqliteConnectionString = builder.Configuration.GetConnectionString("SqLite");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(connectionString: sqliteConnectionString);
});

// Add GraphQl.
builder.Services.AddGraphQL(options =>
{
    options.AddSystemTextJson();
});
builder.Services.AddScoped<CourseQueries>();
builder.Services.AddScoped<AppSchema>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGraphQL<AppSchema>();
app.UseGraphQLGraphiQL("/ui/graphql");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();