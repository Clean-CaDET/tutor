using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.UseCases.ProgressMonitoring;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Enrollments;

namespace Tutor.Web.Controllers.Instructors;

[Authorize(Policy = "instructorPolicy")]
[Route("api/instructors/groups/")]
[ApiController]
public class GroupMonitoringController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IGroupMonitoringService _groupMonitoringMonitoringService;
    
    public GroupMonitoringController(IMapper mapper, IGroupMonitoringService groupMonitoringMonitoringService)
    {
        _mapper = mapper;
        _groupMonitoringMonitoringService = groupMonitoringMonitoringService;
    }

    [HttpGet("{courseId:int}")]
    public ActionResult<List<GroupDto>> GetAssignedGroups(int courseId)
    {
        var result = _groupMonitoringMonitoringService.GetAssignedGroups(User.InstructorId(), courseId);
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value.Select(g => _mapper.Map<GroupDto>(g)).ToList());
    }
}