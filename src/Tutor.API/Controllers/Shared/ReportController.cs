using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos.Reports;
using Tutor.Courses.API.Public.Supervision;

namespace Tutor.API.Controllers.Shared;

[Authorize(Policy = "reportPolicy")]
[Route("api/courses/{courseId:int}/reports/{learnerId:int}")]
public class ReportController : BaseApiController
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("regenerate")]
    public ActionResult<CourseReportDto> Regenerate(int courseId, int learnerId)
    {
        var result = _reportService.Regenerate(courseId, learnerId);
        return CreateResponse(result);
    }

    [HttpGet]
    public ActionResult<CourseReportDto> Get(int courseId, int learnerId)
    {
        var result = _reportService.Get(courseId, learnerId);
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult<CourseReportDto> Create(int courseId, int learnerId, [FromBody] CourseReportDto report)
    {
        report.CourseId = courseId;
        report.LearnerId = learnerId;
        var result = _reportService.Create(report);
        return CreateResponse(result);
    }

    [HttpPut]
    public ActionResult<CourseReportDto> Update(int courseId, int learnerId, [FromBody] CourseReportDto report)
    {
        report.CourseId = courseId;
        report.LearnerId = learnerId;
        var result = _reportService.Update(report);
        return CreateResponse(result);
    }
}