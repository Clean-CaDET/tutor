using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.UseCases.Management.Stakeholder;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Knowledge.DTOs;

namespace Tutor.Web.Controllers.Instructors;

[Authorize(Policy = "instructorPolicy")]
[Route("api/owned-courses")]
public class InstructorController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly ICourseOwnershipService _courseOwnershipService;
    
    public InstructorController(IMapper mapper, ICourseOwnershipService courseOwnershipService)
    {
        _mapper = mapper;
        _courseOwnershipService = courseOwnershipService;
    }

    [HttpGet]
    public ActionResult<List<CourseDto>> GetOwnedCourses()
    {
        var result = _courseOwnershipService.GetOwnedCourses(User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<CourseDto>).ToList());
    }

    [HttpGet("{courseId:int}")]
    public ActionResult<CourseDto> GetCourseWithUnits(int courseId)
    {
        var result = _courseOwnershipService.GetOwnedCourseWithUnits(courseId, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<CourseDto>(result.Value));
    }
}