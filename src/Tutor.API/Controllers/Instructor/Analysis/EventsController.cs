using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.API.Controllers.Instructor.Analysis;

[Authorize(Policy = "instructorPolicy")]
[Route("api/analysis/knowledge-components/events")]
public class EventsController : BaseApiController
{
    private readonly IEventStore _eventStore;
    // Needs to be reworked
    public EventsController(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }
    
    [HttpGet]
    public ActionResult<PagedResult<DomainEvent>> GetEvents([FromQuery] int page, [FromQuery] int pageSize)
    {
        var task = _eventStore.GetEventsAsync(page, pageSize);
        task.Wait();
        return Ok(task.Result);
    }
    
    [HttpGet("all")]
    public ActionResult<List<DomainEvent>> GetAllEvents()
    {
        var result = _eventStore.Events.ToList();
        return Ok(result);
    }

    [HttpGet("learner")]
    public ActionResult<List<DomainEvent>> GetLearnerKcEvents([FromQuery] int learnerId, [FromQuery] int kcId)
    {
        var result = _eventStore.Events.Where(e => 
                e.RootElement.GetProperty("KnowledgeComponentId").GetInt32() == kcId &&
                e.RootElement.GetProperty("LearnerId").GetInt32() == learnerId).ToList();
        return Ok(result);
    }

    [HttpGet("answers/{aiId:int}")]
    public ActionResult<List<DomainEvent>> GetAiSubmissions(int aiId)
    {
        var result = _eventStore.Events.Where(e =>
            e.RootElement.GetProperty("$discriminator").GetString() == "AssessmentItemAnswered" &&
            e.RootElement.GetProperty("AssessmentItemId").GetInt32() == aiId).ToList();
        return Ok(result);
    }
}