using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.InstructorModel;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Controllers.Domain.DTOs.Enrollment;

namespace Tutor.Web.Controllers.Instructors;

[Route("api/instructors/")]
[ApiController]
public class InstructorController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IInstructorService _instructorService;
    
    public InstructorController(IMapper mapper, IInstructorService instructorService)
    {
        _mapper = mapper;
        _instructorService = instructorService;
    }

    [HttpGet("courses")]
    public ActionResult<List<CourseDto>> GetCourses()
    {
        var result = _instructorService.GetCourses(User.Id());
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value.Select(c => _mapper.Map<CourseDto>(c)).ToList());
    }

    [HttpGet("groups/{courseId:int}")]
    public ActionResult<GroupDto> GetGroups(int courseId)
    {
        var result = _instructorService.GetGroups(User.Id(), courseId);
        Console.WriteLine(result.Value);
        return Ok(result.Value.Select(g => _mapper.Map<GroupDto>(g)).ToList());
    }
}