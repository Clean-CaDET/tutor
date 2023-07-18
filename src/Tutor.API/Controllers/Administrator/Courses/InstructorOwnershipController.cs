using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Authoring;
using Tutor.Courses.API.Interfaces.Management;

namespace Tutor.API.Controllers.Administrator.Courses;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/instructors/{instructorId:int}/ownerships")]
public class InstructorOwnershipController : BaseApiController
{
    private readonly ICourseOwnershipService _ownershipService;
    private readonly IOwnedCoursesService _instructorOwnedCoursesService;

    public InstructorOwnershipController(ICourseOwnershipService ownershipService, IOwnedCoursesService instructorOwnedCoursesService)
    {
        _ownershipService = ownershipService;
        _instructorOwnedCoursesService = instructorOwnedCoursesService;
    }

    [HttpGet]
    public ActionResult<List<CourseDto>> GetAll(int instructorId)
    {
        var result = _instructorOwnedCoursesService.GetAll(instructorId);
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult Create(int instructorId, [FromBody] int courseId)
    {
        var result = _ownershipService.AssignOwnership(courseId, instructorId);
        return CreateResponse(result);
    }

    [HttpDelete("{courseId:int}")]
    public ActionResult Delete(int instructorId, int courseId)
    {
        var result = _ownershipService.RemoveOwnership(courseId, instructorId);
        return CreateResponse(result);
    }
}