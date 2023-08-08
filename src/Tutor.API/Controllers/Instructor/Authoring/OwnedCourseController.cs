using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Authoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Authoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/owned-courses")]
public class OwnedCourseController : BaseApiController
{
    private readonly IOwnedCourseService _ownedCourseService;

    public OwnedCourseController(IOwnedCourseService ownedCourseService)
    {
        _ownedCourseService = ownedCourseService;
    }

    [HttpGet]
    public ActionResult<List<CourseDto>> GetOwnedCourses()
    {
        var result = _ownedCourseService.GetAll(User.InstructorId());
        return CreateResponse(result);
    }

    [HttpGet("{courseId:int}")]
    public ActionResult<CourseDto> GetCourseWithUnits(int courseId)
    {
        var result = _ownedCourseService.GetWithUnits(courseId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<CourseDto> Update([FromBody] CourseDto course)
    {
        var result = _ownedCourseService.Update(course, User.InstructorId());
        return CreateResponse(result);
    }
}