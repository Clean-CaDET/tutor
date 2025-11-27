using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos.Reports;
using Tutor.Courses.API.Public.Supervision;

namespace Tutor.API.Controllers.Shared;

[Authorize(Policy = "reportPolicy")]
[Route("api/reports")]
public class ReportController : BaseApiController
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpPost("query")]
    public ActionResult<List<CourseReportDto>> GetMany([FromBody] int[] learnerIds)
    {
        var result = _reportService.GetMany(learnerIds);
        return CreateResponse(result);
    }

    [HttpGet("{courseId:int}/{learnerId:int}")]
    public ActionResult<CourseReportDto> Get(int courseId, int learnerId)
    {
        var result = _reportService.Get(courseId, learnerId);
        return CreateResponse(result);
    }

    [HttpPost("{courseId:int}/{learnerId:int}")]
    public ActionResult<CourseReportDto> Create(int courseId, int learnerId, [FromBody] CourseReportDto report)
    {
        report.CourseId = courseId;
        report.LearnerId = learnerId;
        var result = _reportService.Create(report);
        return CreateResponse(result);
    }

    [HttpPut("{courseId:int}/{learnerId:int}")]
    public ActionResult<CourseReportDto> Update(int courseId, int learnerId, [FromBody] CourseReportDto report)
    {
        report.CourseId = courseId;
        report.LearnerId = learnerId;
        var result = _reportService.Update(report);
        return CreateResponse(result);
    }

    [HttpGet("{courseId:int}/{learnerId:int}/achievements")]
    public ActionResult<CourseReportDto> RegenerateAchievements(int courseId, int learnerId)
    {
        var result = _reportService.RegenerateAchievements(courseId, learnerId);
        return CreateResponse(result);
    }
}