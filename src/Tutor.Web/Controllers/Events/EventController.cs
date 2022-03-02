using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Infrastructure.Database.EventStore;

namespace Tutor.Web.Controllers.Events
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventStore _eventStore;

        public EventController(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        [HttpGet("test")]
        public ActionResult<List<EventDTO>> GetUnits()
        {
            var result = _eventStore.GetEvents(new TimeInterval()).Select(e => new EventDTO(e)).ToList();
            return Ok(result);
        }
    }
}
