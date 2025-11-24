using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Reports;
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

    [HttpGet("{courseId:int}/generate/{learnerId:int}")]
    public ActionResult<CourseReportDto> RegenerateReport(int courseId, int learnerId)
    {
        var result = _reportingService.RegenerateReport(courseId, learnerId);
        return CreateResponse(result);
    }

    [HttpGet("{courseId:int}/report/{learnerId:int}")]
    public ActionResult<CourseReportDto> GetReport(int courseId, int learnerId)
    {
        var result = _reportingService.GetReport(courseId, learnerId);
        return CreateResponse(result);
    }

    [HttpPost("{courseId:int}/report/{learnerId:int}")]
    public ActionResult<CourseReportDto> CreateReport(int courseId, int learnerId, [FromBody] CourseReportDto report)
    {
        report.CourseId = courseId;
        report.LearnerId = learnerId;
        var result = _reportingService.CreateReport(report);
        return CreateResponse(result);
    }

    [HttpPut("{courseId:int}/report/{learnerId:int}")]
    public ActionResult<CourseReportDto> UpdateReport(int courseId, int learnerId, [FromBody] CourseReportDto report)
    {
        report.CourseId = courseId;
        report.LearnerId = learnerId;
        var result = _reportingService.UpdateReport(report);
        return CreateResponse(result);
    }
}