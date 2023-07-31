using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Management;

namespace Tutor.API.Controllers.Administrator.Courses;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/courses")]
public class CourseController : BaseApiController
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public ActionResult<List<CourseDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _courseService.GetAll(page, pageSize);
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult<CourseDto> Create([FromBody] CourseDto course)
    {
        var result = _courseService.Create(course);
        return CreateResponse(result);
    }

    [HttpPost("{id:int}/clone")]
    public ActionResult<CourseDto> Clone(int id)
    {
        var result = _courseService.Clone(id);
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<CourseDto> Update([FromBody] CourseDto course)
    {
        var result = _courseService.Update(course);
        return CreateResponse(result);
    }

    [HttpPatch("{id:int}/archive")]
    public ActionResult<CourseDto> Archive(int id, [FromBody] bool archive)
    {
        var result = _courseService.Archive(id, archive);
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _courseService.Delete(id);
        return CreateResponse(result);
    }
}