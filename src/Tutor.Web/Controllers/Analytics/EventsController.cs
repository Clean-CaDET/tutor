using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Infrastructure.Database.BuildingBlocks;
using Tutor.Infrastructure.Database.EventStore;

namespace Tutor.Web.Controllers.Analytics;

[Route("api/events")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly IEventStore _eventStore;

    public EventsController(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    [HttpGet]
    public ActionResult<PagedResult<DomainEvent>> GetEvents([FromQuery] int page, [FromQuery] int pageSize)
    {
        var task = _eventStore.GetEventsAsync(page, pageSize);
        Task.WaitAll(task);
        return Ok(task.Result);
    }
}