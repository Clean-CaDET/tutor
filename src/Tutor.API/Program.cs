using Serilog;
using Tutor.API.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();
builder.Services.ConfigureSwagger(builder.Configuration);
const string corsPolicy = "_corsPolicy";
builder.Services.ConfigureCors(corsPolicy);
builder.Services.ConfigureAuth();

builder.Services.RegisterModules();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseRouting();
app.UseCors(corsPolicy);
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();

// Required for automated tests
namespace Tutor.API
{
    public partial class Program { }
}

// TODO: CourseOwnership service was split into CourseOwnership and OwnedCourses. Check if everything is ok
// TODO: LearnerGroupService was split into two.
// TODO: EnrollmentService was split into Enrollment and EnrolledCourse service
// TODO: Associations with some stakeholder classes were severed (e.g., course ownership)
// TODO: Enrollment should generate mastery
// TODO: Enrollment status je deactivated
// TODO: DELETE operations need to be revisited because of modules.

// TODO: KcRating should be moved from utilities to learning

// TODO: Check if dahomey is used in Event Infrastructure // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/polymorphism?pivots=dotnet-7-0
// TODO: Check Event context and UoW behavior