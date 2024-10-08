﻿using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Public.Monitoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring/{courseId:int}/groups")]
public class GroupMonitoringController : BaseApiController
{
    private readonly IGroupMonitoringService _groupMonitoringService;

    public GroupMonitoringController(IGroupMonitoringService groupMonitoringService)
    {
        _groupMonitoringService = groupMonitoringService;
    }

    [HttpGet]
    public ActionResult<List<GroupDto>> GetCourseGroups(int courseId)
    {
        var result = _groupMonitoringService.GetCourseGroups(User.InstructorId(), courseId);
        var pagedResult = new PagedResult<GroupDto>(result.Value, result.Value.Count).ToResult();
        return CreateResponse(pagedResult);
    }

    [HttpGet("{groupId:int}")]
    public ActionResult<PagedResult<LearnerDto>> GetLearners(int courseId, int groupId, [FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _groupMonitoringService.GetLearners(User.InstructorId(), courseId, groupId, page, pageSize);
        return CreateResponse(result);
    }
}