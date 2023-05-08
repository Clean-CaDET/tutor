using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.UseCases.Monitoring;
using Tutor.Web.Controllers.Instructors.Monitoring;
using Tutor.Web.Mappings.Session;
using Xunit;

namespace Tutor.Web.Tests.Integration.Monitoring;

public class CalendarTests : BaseWebIntegrationTest
{
    public CalendarTests(TutorApplicationTestFactory<Startup> factory) : base(factory)
    {
    }
    
    [Theory]
    [InlineData("-51", -3, 1)]
    public void Retrieves_sessions_successfully(string instructorId, int learnerId, int expectedResult)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope, instructorId);
        var result = ((OkObjectResult)controller.GetSessions(learnerId).Result)?.Value as List<SessionDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedResult);
    }
    
    private CalendarController SetupController(IServiceScope scope, string id)
    {
        return new CalendarController(scope.ServiceProvider.GetRequiredService<ICalendarService>(),
            Factory.Services.GetRequiredService<IMapper>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}