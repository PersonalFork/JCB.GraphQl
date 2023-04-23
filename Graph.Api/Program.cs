using Graph.Data;
using Graph.Data.Repositories;
using Graph.Interfaces.Services;
using Graph.Services;
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();