using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Core.UseCases.Monitoring;
using Tutor.Web.Controllers.Instructors.Monitoring;
using Tutor.Web.Mappings.Enrollments;
using Xunit;

namespace Tutor.Web.Tests.Integration.Monitoring;

[Collection("Sequential")]
public class UnitEnrollmentQueryTests : BaseWebIntegrationTest
{
    public UnitEnrollmentQueryTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}
    
    [Theory]
    [InlineData("-51", -1, new[] {-1, -2, -3, -4, -5}, 4)]
    [InlineData("-51", -2, new[] {-1, -2, -3, -4, -5}, 2)]
    public void Gets_enrollments(string instructorId, int unitId, int[] learnerIds, int expectedEnrollmentCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope, instructorId);
        var result = ((OkObjectResult)controller.GetEnrollments(unitId, learnerIds).Result)?.Value as List<UnitEnrollmentDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedEnrollmentCount);
    }

    private UnitEnrollmentController SetupController(IServiceScope scope, string id)
    {
        return new UnitEnrollmentController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<IEnrollmentService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}