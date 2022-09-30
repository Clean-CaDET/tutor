using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Web.Controllers.Domain.DTOs;
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
        var result = ((OkObjectResult)controller.GetByCourse(courseId).Result)?.Value as List<UnitDto>;

        result.Count.ShouldBe(expectedResult);
    }
}