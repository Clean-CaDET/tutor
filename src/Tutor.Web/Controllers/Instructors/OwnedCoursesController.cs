using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Knowledge.DTOs;

namespace Tutor.Web.Controllers.Instructors;

[Authorize(Policy = "instructorPolicy")]
[Route("api/owned-courses")]
public class OwnedCoursesController : BaseApiController
{
    private readonly ICourseOwnershipService _courseOwnershipService;
    
    public OwnedCoursesController(IMapper mapper, ICourseOwnershipService courseOwnershipService) : base(mapper)
    {
        _courseOwnershipService = courseOwnershipService;
    }

    [HttpGet]
    public ActionResult<List<CourseDto>> GetOwnedCourses()
    {
        var result = _courseOwnershipService.GetOwnedCourses(User.InstructorId());
        return CreateResponse<Course, CourseDto>(result);
    }

    [HttpGet("{courseId:int}")]
    public ActionResult<CourseDto> GetCourseWithUnitsAndKcs(int courseId)
    {
        var result = _courseOwnershipService.GetOwnedCourseWithUnitsAndKcs(courseId, User.InstructorId());
        return CreateResponse<Course, CourseDto>(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<CourseDto> Update([FromBody] CourseDto course)
    {
        var result = _courseOwnershipService.UpdateOwnedCourse(_mapper.Map<Course>(course), User.InstructorId());
        return CreateResponse<Course, CourseDto>(result);
    }
}