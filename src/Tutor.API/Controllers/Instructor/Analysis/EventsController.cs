using System.Text.Json;
using Dahomey.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.KnowledgeComponents.Core.Domain.EventSourcing;
using Tutor.KnowledgeComponents.Infrastructure.Database.EventStore;
using Tutor.KnowledgeComponents.Infrastructure.Database.EventStore.DefaultEventSerializer;

namespace Tutor.API.Controllers.Instructor.Analysis;

[Authorize(Policy = "instructorPolicy")]
[Route("api/analysis/knowledge-components/events")]
public class EventsController : BaseApiController
{
    private readonly IKnowledgeComponentEventStore _eventStore;
    // Needs to be reworked and expanded into a service.
    // The main issue is that we are tied to Dahomey until https://github.com/dotnet/runtime/issues/73693 is resolved.
    public EventsController(IKnowledgeComponentEventStore eventStore)
    {
        _eventStore = eventStore;
    }
    
    [HttpPost]
    public ActionResult<string> GetUnitEvents([FromBody] int[] kcIds)
    {
        var result = _eventStore.Events.Where(e =>
            kcIds.Any(id => e.RootElement.GetProperty("KnowledgeComponentId").GetInt32() == id)).ToList();
        return Ok(JsonSerializer.Serialize(result, ConfigureOptions()));
    }

    [HttpGet("learner")]
    public ActionResult<string> GetLearnerKcEvents([FromQuery] int learnerId, [FromQuery] int kcId)
    {
        var result = _eventStore.Events.Where(e => 
                e.RootElement.GetProperty("KnowledgeComponentId").GetInt32() == kcId &&
                e.RootElement.GetProperty("LearnerId").GetInt32() == learnerId).ToList();
        return Ok(JsonSerializer.Serialize(result, ConfigureOptions()));
    }

    [HttpGet("answers/{aiId:int}")]
    public ActionResult<string> GetAiSubmissions(int aiId)
    {
        var result = _eventStore.Events.Where(e =>
            e.RootElement.GetProperty("$discriminator").GetString() == "AssessmentItemAnswered" &&
            e.RootElement.GetProperty("AssessmentItemId").GetInt32() == aiId).ToList();
        return Ok(JsonSerializer.Serialize(result, ConfigureOptions()));
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