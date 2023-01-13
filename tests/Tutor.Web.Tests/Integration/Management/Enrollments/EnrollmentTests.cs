using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Core.UseCases.Management.Enrollments;
using Tutor.Web.Controllers.Learners;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration.Management.Enrollments;

public class EnrollmentTests : BaseWebIntegrationTest
{
    public EnrollmentTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Theory]
    [InlineData("-1", 2)]
    [InlineData("-2", 2)]
    public void Retrieves_enrolled_courses(string learnerId, int expectedCourseCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupEnrollmentController(scope, learnerId);
        var result = ((OkObjectResult)controller.GetEnrolledCourses().Result)?.Value as List<CourseDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedCourseCount);
    }

    [Theory]
    [InlineData(-2, -1, 2)]
    [InlineData(-1, -1, 0)]
    public void Retrieves_course_with_enrolled_and_active_units(int learnerId, int courseId, int expectedUnitCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupEnrollmentController(scope, learnerId.ToString());

        var course = ((OkObjectResult)controller.GetCourseWithEnrolledAndActiveUnits(courseId).Result).Value as CourseDto;

        course.KnowledgeUnits.Count.ShouldBe(expectedUnitCount);
    }

    private EnrollmentController SetupEnrollmentController(IServiceScope scope, string id)
    {
        return new EnrollmentController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<IEnrollmentService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}