using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.UseCases.ProgressMonitoring;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Analytics;
using Tutor.Web.Mappings.Enrollments;

namespace Tutor.Web.Controllers.Instructors;

[Authorize(Policy = "instructorPolicy")]
[Route("api/instructors/monitoring/{courseId:int}/")]
[ApiController]
public class CourseIterationMonitoringController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICourseIterationMonitoringService _courseIterationMonitoringService;
    
    public CourseIterationMonitoringController(IMapper mapper, ICourseIterationMonitoringService courseIterationMonitoringService)
    {
        _mapper = mapper;
        _courseIterationMonitoringService = courseIterationMonitoringService;
    }

    [HttpGet]
    public ActionResult<List<GroupDto>> GetAssignedGroups(int courseId)
    {
        var result = _courseIterationMonitoringService.GetAssignedGroups(User.InstructorId(), courseId);
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<GroupDto>).ToList());
    }

    [HttpGet("groups/")]
    public ActionResult<PagedResult<LearnerProgressDto>> GetProgressForAll(int courseId, [FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _courseIterationMonitoringService.GetLearnersWithProgress(courseId, page, pageSize);
        var progress = result.Results.Select(_mapper.Map<LearnerProgressDto>).ToList();
        return Ok(new PagedResult<LearnerProgressDto>(progress, result.TotalCount));
    }

    [HttpGet("groups/{groupId:int}")]
    public ActionResult<PagedResult<LearnerProgressDto>> GetProgressForGroup(int courseId, int groupId, [FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _courseIterationMonitoringService.GetLearnersWithProgressForGroup(courseId, groupId, page, pageSize);
        var progress = result.Results.Select(_mapper.Map<LearnerProgressDto>).ToList();
        return Ok(new PagedResult<LearnerProgressDto>(progress, result.TotalCount));
    }
}