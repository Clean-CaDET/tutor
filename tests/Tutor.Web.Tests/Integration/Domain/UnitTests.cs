using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Web.Controllers.Instructors;
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

    private UnitController SetupUnitController(IServiceScope scope, string id)
    {
        return new UnitController(scope.ServiceProvider.GetRequiredService<IKnowledgeUnitRepository>(),
            Factory.Services.GetRequiredService<IMapper>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}