using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Public.Management;

namespace Tutor.API.Controllers.Administrator.Courses;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/courses/{courseId:int}/owners")]
public class CourseOwnerController : BaseApiController
{
    private readonly ICourseOwnershipService _ownershipService;

    public CourseOwnerController(ICourseOwnershipService ownershipService)
    {
        _ownershipService = ownershipService;
    }

    [HttpGet]
    public ActionResult<List<InstructorDto>> GetAll(int courseId)
    {
        var result = _ownershipService.GetOwners(courseId);
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult Create(int courseId, [FromBody] int instructorId)
    {
        var result = _ownershipService.AssignOwnership(courseId, instructorId);
        return CreateResponse(result);
    }

    [HttpDelete("{instructorId:int}")]
    public ActionResult Delete(int courseId, int instructorId)
    {
        var result = _ownershipService.RemoveOwnership(courseId, instructorId);
        return CreateResponse(result);
    }
}