using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.UseCases.KnowledgeAnalysis;
using Tutor.Web.Controllers.Instructors;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration.KnowledgeAnalysis;

[Collection("Sequential")]
public class EventsTests : BaseWebIntegrationTest
{
    public EventsTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Fact]
    public void Retrieves_all_events()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupEventsController(scope, "-50");

        var result = ((OkObjectResult)controller.GetAllEvents().Result).Value as List<DomainEvent>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(103);
    }

    [Theory]
    [InlineData(1, 60, 60)]
    [InlineData(2, 60, 43)]
    public void Retrieves_subset_of_events(int page, int pageSize, int expectedEventCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupEventsController(scope, "-50");

        var result = ((OkObjectResult)controller.GetEvents(page, pageSize).Result).Value as PagedResult<DomainEvent>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(expectedEventCount);
    }

    private static EventsController SetupEventsController(IServiceScope scope, string id)
    {
        return new EventsController(scope.ServiceProvider.GetRequiredService<IEventStore>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
    
}
