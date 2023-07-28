using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Analysis;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.KnowledgeComponents.Tests.Integration.Analysis;

[Collection("Sequential")]
public class EventsTests : BaseKnowledgeComponentsIntegrationTest
{
    public EventsTests(KnowledgeComponentsTestFactory factory) : base(factory) { }

    [Fact]
    public void Retrieves_all_events()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-51");

        var result = ((OkObjectResult)controller.GetAllEvents().Result).Value as List<DomainEvent>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(99);
    }

    [Theory]
    [InlineData(1, 60, 60)]
    [InlineData(2, 60, 39)]
    public void Retrieves_subset_of_events(int page, int pageSize, int expectedEventCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-51");

        var result = ((OkObjectResult)controller.GetEvents(page, pageSize).Result).Value as PagedResult<DomainEvent>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(expectedEventCount);
    }

    private static EventsController CreateController(IServiceScope scope, string id)
    {
        return new EventsController(scope.ServiceProvider.GetRequiredService<IEventStore>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}