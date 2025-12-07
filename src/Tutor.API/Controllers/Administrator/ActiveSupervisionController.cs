using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Dtos.Reflections;
using Tutor.Courses.API.Public.Supervision;

namespace Tutor.API.Controllers.Administrator;

[Authorize(Policy = "administratorPolicy")]
[Route("api/supervision/active")]
public class ActiveSupervisionController : BaseApiController
{
    private readonly IActiveSupervisionService _monitoringService;

    public ActiveSupervisionController(IActiveSupervisionService monitoringService)
    {
        _monitoringService = monitoringService;
    }

    [HttpGet]
    public ActionResult<List<CourseDto>> GetActiveCourses()
    {
        var result = _monitoringService.GetActiveCourses();
        return CreateResponse(result);
    }

    [HttpGet("{courseId:int}")]
    public ActionResult<List<GroupDto>> GetGroupOverview(int courseId)
    {
        var result = _monitoringService.GetGroupedLearnersWithFeedback(courseId);
        return CreateResponse(result);
    }

    [HttpGet("reflections/{learnerId:int}")]
    public ActionResult<List<ReflectionDto>> GetReflections(int learnerId, [FromQuery] List<int>? reflectionIds)
    {
        var result = _monitoringService.GetReflections(learnerId, reflectionIds);
        return CreateResponse(result);
    }
}