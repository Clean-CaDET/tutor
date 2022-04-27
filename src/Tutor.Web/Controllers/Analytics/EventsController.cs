using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks.EventSourcing;
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
    public ActionResult<IEnumerable<DomainEvent>> GetEvents()
    {
        return Ok(_eventStore.GetEvents(null, null));
    }
}