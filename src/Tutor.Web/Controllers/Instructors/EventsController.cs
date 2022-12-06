﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Web.Controllers.Instructors;

[Authorize(Policy = "instructorPolicy")]
[Route("api/events")]
public class EventsController : BaseApiController
{
    private readonly IEventStore _eventStore;

    public EventsController(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }
    
    [HttpGet("")]
    public ActionResult<PagedResult<DomainEvent>> GetEvents([FromQuery] int page, [FromQuery] int pageSize)
    {
        var task = _eventStore.GetEventsAsync(page, pageSize);
        task.Wait();
        return Ok(task.Result);
    }
    
    [HttpGet("all/")]
    public ActionResult<List<DomainEvent>> GetAllEvents()
    {
        var result = _eventStore.Events.ToList();
        return Ok(result);
    }
}