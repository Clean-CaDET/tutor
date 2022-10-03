using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.EnrollmentModel;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Controllers.Domain.DTOs;

namespace Tutor.Web.Controllers.Instructors;

[Authorize(Policy = "instructorPolicy")]
[Route("api/instructors/")]
[ApiController]
public class InstructorController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IEnrollmentService _enrollmentService;
    
    public InstructorController(IMapper mapper, IEnrollmentService enrollmentService)
    {
        _mapper = mapper;
        _enrollmentService = enrollmentService;
    }

    [HttpGet("courses")]
    public ActionResult<List<CourseDto>> GetOwnedCourses()
    {
        var result = _enrollmentService.GetOwnedCourses(User.InstructorId());
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value.Select(c => _mapper.Map<CourseDto>(c)).ToList());
    }

    [HttpGet("groups/{courseId:int}")]
    public ActionResult<GroupDto> GetAssignedGroups(int courseId)
    {
        var result = _enrollmentService.GetAssignedGroups(User.InstructorId(), courseId);
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value.Select(g => _mapper.Map<GroupDto>(g)).ToList());
    }
}