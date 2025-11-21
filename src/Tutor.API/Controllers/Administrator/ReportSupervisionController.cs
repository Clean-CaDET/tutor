using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Reflections;
using Tutor.Courses.API.Public.Monitoring;

namespace Tutor.API.Controllers.Administrator;

[Authorize(Policy = "administratorPolicy")]
[Route("api/supervision/reporting")]
public class ReportSupervisionController : BaseApiController
{
    private readonly ICourseMonitoringService _monitoringService;

    public ReportSupervisionController(ICourseMonitoringService monitoringService)
    {
        _monitoringService = monitoringService;
    }

    [HttpGet]
    public ActionResult<List<CourseDto>> GetStartedCourses()
    {
        var result = _monitoringService.GetStartedCourses();
        return CreateResponse(result);
    }

    [HttpGet("{courseId:int}")]
    public ActionResult<CourseDto> GetCourseWithGroupsAndUnits(int courseId)
    {
        var result = _monitoringService.GetCourseWithGroupsAndUnits(courseId);
        return CreateResponse(result);
    }

    [HttpPost("{courseId:int}/achievements/{learnerId:int}")]
    public ActionResult<List<ReflectionAnswerDto>> GetAchievements(int courseId, int learnerId, [FromBody] AchievementsRequestDto ids)
    {
        var result = _monitoringService.GetAchievements(courseId, learnerId, ids);
        return CreateResponse(result);
    }
}