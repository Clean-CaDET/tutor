﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.UseCases.ProgressMonitoring;
using Tutor.Core.UseCases.StakeholderManagement;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Enrollments;
using Tutor.Web.Mappings.Knowledge.DTOs;

namespace Tutor.Web.Controllers.Instructors;

[Authorize(Policy = "instructorPolicy")]
[Route("api/instructors/")]
[ApiController]
public class InstructorController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAvailableCourseService _availableCourseService;
    private readonly IGroupMonitoringService _groupMonitoringMonitoringService;
    
    public InstructorController(IMapper mapper, IAvailableCourseService availableCourseService, IGroupMonitoringService groupMonitoringMonitoringService)
    {
        _mapper = mapper;
        _availableCourseService = availableCourseService;
        _groupMonitoringMonitoringService = groupMonitoringMonitoringService;
    }

    [HttpGet("courses")]
    public ActionResult<List<CourseDto>> GetOwnedCourses()
    {
        var result = _availableCourseService.GetOwnedCourses(User.InstructorId());
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value.Select(c => _mapper.Map<CourseDto>(c)).ToList());
    }

    [HttpGet("groups/{courseId:int}")]
    public ActionResult<GroupDto> GetAssignedGroups(int courseId)
    {
        var result = _groupMonitoringMonitoringService.GetAssignedGroups(User.InstructorId(), courseId);
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value.Select(g => _mapper.Map<GroupDto>(g)).ToList());
    }
}