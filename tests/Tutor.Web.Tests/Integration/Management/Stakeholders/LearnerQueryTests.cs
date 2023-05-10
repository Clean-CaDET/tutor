using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Core.UseCases.Monitoring;
using Tutor.Web.Controllers.Administrators.Stakeholders;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Tutor.Web.Mappings.Stakeholders;
using Xunit;

namespace Tutor.Web.Tests.Integration.Management.Stakeholders;

[Collection("Sequential")]
public class LearnerQueryTests : BaseWebIntegrationTest
{
    public LearnerQueryTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Theory]
    [MemberData(nameof(LearnerData))]
    public void Retrieves_learners(string[] indexes, int expectedCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupLearnerController(scope);

        var result = ((OkObjectResult)controller.GetSelected(indexes).Result)?.Value as PagedResult<StakeholderAccountDto>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(expectedCount);
        result.TotalCount.ShouldBe(expectedCount);
    }

    public static IEnumerable<object[]> LearnerData()
    {
        return new List<object[]>
        {
            new object[]
            {
                new[] { "SU-1-2021" },
                1
            },
            new object[]
            {
                new[] { "SU-1-2021", "SU-2-2021", "SU-3-2021" },
                3
            },
            new object[]
            {
                new[] { "SU-1-2021", "SU-1-2021", "SU-1-2021" },
                1
            },
            new object[]
            {
                new[] { "SU-1-2021", "SU-222-2021" },
                1
            }
        };
    }

    [Fact]
    public void Retrieves_learners_with_bad_argument()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupLearnerController(scope);

        var result = (ObjectResult)controller.GetSelected(null).Result;

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(400);
    }

    [Fact]
    public void Retrieves_learner_courses()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupLearnerController(scope);

        var result = ((OkObjectResult)controller.GetEnrolledCourses(-1, 0, 0).Result)?.Value as PagedResult<CourseDto>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(2);
        result.TotalCount.ShouldBe(2);
    }

    [Fact]
    public void Retrieves_paged_learners_with_roles()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupLearnerController(scope);

        var result = ((OkObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<StakeholderAccountDto>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(7);
        result.TotalCount.ShouldBe(7);
        foreach (var item in result.Results)
        {
            item.ShouldNotBeNull();
            item.UserType.ShouldNotBeNull();
        }
    }

    private LearnerController SetupLearnerController(IServiceScope scope)
    {
        return new LearnerController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<ILearnerService>(), scope.ServiceProvider.GetRequiredService<IEnrollmentService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}