using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.UseCases.Monitoring;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Enrollments;

namespace Tutor.Web.Controllers.Instructors;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring/{courseId:int}/groups")]
public class GroupMonitoringController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IGroupMonitoringService _groupMonitoringService;
    
    public GroupMonitoringController(IMapper mapper, IGroupMonitoringService groupMonitoringService)
    {
        _mapper = mapper;
        _groupMonitoringService = groupMonitoringService;
    }

    [HttpGet]
    public ActionResult<List<GroupDto>> GetCourseGroups(int courseId)
    {
        var result = _groupMonitoringService.GetCourseGroups(User.InstructorId(), courseId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<GroupDto>).ToList());
    }

    [HttpGet("progress")]
    public ActionResult<PagedResult<LearnerProgressDto>> GetProgressForAll(int courseId, [FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _groupMonitoringService.GetLearnersWithProgress(courseId, User.InstructorId(), page, pageSize);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return CreateResponse(result.Value);
    }

    private ActionResult<PagedResult<LearnerProgressDto>> CreateResponse(PagedResult<Learner> result)
    {
        var progress = result.Results.Select(_mapper.Map<LearnerProgressDto>).ToList();
        return Ok(new PagedResult<LearnerProgressDto>(progress, result.TotalCount));
    }

    [HttpGet("progress/{groupId:int}")]
    public ActionResult<PagedResult<LearnerProgressDto>> GetProgressForGroup(int courseId, int groupId, [FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _groupMonitoringService.GetLearnersWithProgressForGroup(courseId, User.InstructorId(), groupId, page, pageSize);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return CreateResponse(result.Value);
    }
}