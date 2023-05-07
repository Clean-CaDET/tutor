using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Tutor.Core.Domain.Session;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.UseCases.Monitoring;
using Tutor.Web.Mappings.Session;
using Tutor.Web.Mappings.Stakeholders;

namespace Tutor.Web.Controllers.Instructors.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/calendar")]
public class CalendarController : BaseApiController
{
    private readonly ICalendarService _calendarService;
    
    public CalendarController(ICalendarService calendarService, IMapper mapper) : base(mapper)
    {
        _calendarService = calendarService;
    }
    
    [HttpGet("sessions")]
    public ActionResult<List<Session>> GetSessions([FromQuery] int learnerId)
    {
        var result = _calendarService.GetSessions(learnerId);
        return CreateResponse<Session, SessionDto>(result);
    }
    
    [HttpGet("learner")]
    public ActionResult<LearnerDto> GetLearnerInfo([FromQuery] int learnerId)
    {
        var result = _calendarService.GetLearner(learnerId);
        Console.WriteLine(result.Value.Id);
        return CreateResponse<Learner, LearnerDto>(result);
    }
}