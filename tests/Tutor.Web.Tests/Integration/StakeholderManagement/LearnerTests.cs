using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Core.UseCases.StakeholderManagement;
using Tutor.Web.Controllers.Learners;
using Tutor.Web.Mappings.CourseIteration;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration.StakeholderManagement;

[Collection("Sequential")]
public class LearnerTests : BaseWebIntegrationTest
{
    public LearnerTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}

    [Theory]
    [InlineData("-1", "SU-1-2021")]
    [InlineData("-2", "SU-2-2021")]
    public void Retrieves_profile(string learnerId, string expectedIndex)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupLearnerController(scope, learnerId);
        var result = ((OkObjectResult)controller.GetLearnerProfile().Result)?.Value as LearnerDto;

        result.ShouldNotBeNull();
        result.Index.ShouldBe(expectedIndex);
    }

    [Theory]
    [InlineData("-1", 2)]
    [InlineData("-2", 2)]
    public void Retrieves_enrolled_courses(string learnerId, int expectedCourseCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupLearnerController(scope, learnerId);
        var result = ((OkObjectResult)controller.GetEnrolledCourses().Result)?.Value as List<CourseDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedCourseCount);
    }

    private LearnerController SetupLearnerController(IServiceScope scope, string id)
    {
        return new LearnerController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<ILearnerService>(), scope.ServiceProvider.GetRequiredService<IAvailableCourseService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}