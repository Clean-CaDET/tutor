using Dahomey.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Text.Json;
using Tutor.API.Controllers.Instructor.Analysis;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.KnowledgeComponents.Core.Domain.EventSourcing;
using Tutor.KnowledgeComponents.Infrastructure.Database.EventStore;
using Tutor.KnowledgeComponents.Infrastructure.Database.EventStore.DefaultEventSerializer;

namespace Tutor.KnowledgeComponents.Tests.Integration.Analysis;

[Collection("Sequential")]
public class EventsTests : BaseKnowledgeComponentsIntegrationTest
{
    public EventsTests(KnowledgeComponentsTestFactory factory) : base(factory) { }

    [Fact]
    public void Retrieves_unit_events()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-51");

        var result = ((OkObjectResult)controller.GetUnitEvents(new []{-10, -11, -12}).Result).Value.ToString();

        var events = JsonSerializer.Deserialize(result, typeof(List<DomainEvent>), ConfigureOptions()) as List<DomainEvent>;
        events.ShouldNotBeNull();
        events.Count.ShouldBe(83);
    }

    [Fact]
    public void Retrieves_learner_events()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-51");

        var result = ((OkObjectResult)controller.GetLearnerKcEvents(-5, -10).Result).Value.ToString();

        var events = JsonSerializer.Deserialize(result, typeof(List<DomainEvent>), ConfigureOptions()) as List<DomainEvent>;
        events.ShouldNotBeNull();
        events.Count.ShouldBe(11);
    }

    [Fact]
    public void Retrieves_submissions()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-51");

        var result = ((OkObjectResult)controller.GetAiSubmissions(-999).Result).Value.ToString();

        var events = JsonSerializer.Deserialize(result, typeof(List<DomainEvent>), ConfigureOptions()) as List<DomainEvent>;
        events.ShouldNotBeNull();
        events.Count.ShouldBe(0);
    }

    private static EventsController CreateController(IServiceScope scope, string id)
    {
        return new EventsController(scope.ServiceProvider.GetRequiredService<IKnowledgeComponentEventStore>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }

    private static JsonSerializerOptions ConfigureOptions()
    {
        var serializerOptions = new JsonSerializerOptions();
        serializerOptions.SetupExtensions();
        var registry = serializerOptions.GetDiscriminatorConventionRegistry();

        registry.RegisterConvention(new AllowedTypesDiscriminatorConvention<string>(
            serializerOptions, EventSerializationConfiguration.EventRelatedTypes, "$discriminator"));
        foreach (var type in EventSerializationConfiguration.EventRelatedTypes.Keys)
        {
            registry.RegisterType(type);
        }
        return serializerOptions;
    }
}