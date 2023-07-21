using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Monitoring;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Monitoring;

namespace Tutor.Courses.Tests.Integration.Monitoring;

[Collection("Sequential")]
public class UnitEnrollmentQueryTests : BaseCoursesIntegrationTest
{
    public UnitEnrollmentQueryTests(CoursesTestFactory factory) : base(factory) {}
    
    [Theory]
    [InlineData("-51", -1, new[] {-1, -2, -3, -4, -5}, 4)]
    [InlineData("-51", -2, new[] {-1, -2, -3, -4, -5}, 2)]
    public void Gets_enrollments(string instructorId, int unitId, int[] learnerIds, int expectedEnrollmentCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, instructorId);
        var result = ((OkObjectResult)controller.GetEnrollments(unitId, learnerIds).Result)?.Value as List<UnitEnrollmentDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedEnrollmentCount);
    }

    private static UnitEnrollmentController CreateController(IServiceScope scope, string id)
    {
        return new UnitEnrollmentController(scope.ServiceProvider.GetRequiredService<IEnrollmentService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}