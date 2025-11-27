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
    public ActionResult<CourseDto> GetGroupedLearnersWithReports(int courseId)
    {
        var result = _reportingService.GetGroupedLearnersWithReports(courseId);
        return CreateResponse(result);
    }
}