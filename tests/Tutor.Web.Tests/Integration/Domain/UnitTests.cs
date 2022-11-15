using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using AutoMapper;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.UseCases.StakeholderManagement;
using Tutor.Web.Controllers.Instructors;
using Tutor.Web.Controllers.Learners;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration.Domain;

[Collection("Sequential")]
public class UnitTests : BaseWebIntegrationTest
{
    public UnitTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}
    
    [Theory]
    [InlineData(-1, 2)]
    public void Get_units_by_course(int courseId, int expectedResult)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupUnitController(scope, "-51");
        var result = ((OkObjectResult)controller.GetByCourse(courseId).Result)?.Value as List<KnowledgeUnitDto>;

        result.Count.ShouldBe(expectedResult);
    }

    [Theory]
    [InlineData(-1, 1)]
    public void Get_units_by_enrollment_status(int courseId, int expectedResult)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupLearnerController(scope, "-2");
        var result = ((OkObjectResult)controller.GetUnitsByEnrollmentStatus(courseId).Result)?.Value as List<KnowledgeUnitDto>;

        result.Count.ShouldBe(expectedResult);
    }

    private LearnerController SetupLearnerController(IServiceScope scope, string id)
    {
        return new LearnerController(scope.ServiceProvider.GetRequiredService<ILearnerService>(),
            Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<IAvailableCourseService>(),
            scope.ServiceProvider.GetRequiredService<IKnowledgeUnitRepository>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }

    private UnitController SetupUnitController(IServiceScope scope, string id)
    {
        return new UnitController(scope.ServiceProvider.GetRequiredService<IKnowledgeUnitRepository>(),
            Factory.Services.GetRequiredService<IMapper>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}