using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Authoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Authoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/owned-courses")]
public class OwnedCourseController : BaseApiController
{
    private readonly IOwnedCoursesService _ownedCoursesService;

    public OwnedCourseController(IOwnedCoursesService ownedCoursesService)
    {
        _ownedCoursesService = ownedCoursesService;
    }

    [HttpGet]
    public ActionResult<List<CourseDto>> GetOwnedCourses()
    {
        var result = _ownedCoursesService.GetAll(User.InstructorId());
        return CreateResponse(result);
    }

    [HttpGet("{courseId:int}")]
    public ActionResult<CourseDto> GetCourseWithUnits(int courseId)
    {
        var result = _ownedCoursesService.GetWithUnits(courseId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<CourseDto> Update([FromBody] CourseDto course)
    {
        var result = _ownedCoursesService.Update(course, User.InstructorId());
        return CreateResponse(result);
    }
}