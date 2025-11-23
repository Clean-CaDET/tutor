using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Supervision;

namespace Tutor.API.Controllers.Administrator;

[Authorize(Policy = "administratorPolicy")]
[Route("api/supervision/reporting")]
public class ReportSupervisionController : BaseApiController
{
    private readonly ICourseReportingService _reportingService;

    public ReportSupervisionController(ICourseReportingService reportingService)
    {
        _reportingService = reportingService;
    }

    [HttpGet]
    public ActionResult<List<CourseDto>> GetStartedCourses()
    {
        var result = _reportingService.GetStartedCourses();
        return CreateResponse(result);
    }

    [HttpGet("{courseId:int}")]
    public ActionResult<CourseDto> GetCourseWithGroupsAndUnits(int courseId)
    {
        var result = _reportingService.GetCourseWithGroupsAndUnits(courseId);
        return CreateResponse(result);
    }

    [HttpGet("{courseId:int}/achievements/{learnerId:int}")]
    public ActionResult<CourseAchievementsDto> GetAchievements(int courseId, int learnerId)
    {
        var result = _reportingService.GetAchievements(courseId, learnerId);
        return CreateResponse(result);
    }
}