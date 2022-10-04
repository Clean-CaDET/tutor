using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Web.Mappings.Domain.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration.Domain;

public class UnitTests : BaseWebIntegrationTest
{
    public UnitTests(TutorApplicationTestFactory<Startup> factory) : base(factory)
    {
    }
    
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
}