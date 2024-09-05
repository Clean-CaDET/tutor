using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Monitoring;
using Tutor.Courses.API.Public.Monitoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring/learners")]
public class ProgressMonitoringController : BaseApiController
{
    private readonly IProgressMonitoringService _monitoringService;

    public ProgressMonitoringController(IProgressMonitoringService monitoringService)
    {
        _monitoringService = monitoringService;
    }

    [HttpGet("{learnerId:int}")]
    public ActionResult<List<UnitHeaderDto>> GetWeeklyUnitsWithTasksAndKcs(int learnerId, [FromQuery] int courseId, [FromQuery] DateTime weekEnd)
    {
        var result = _monitoringService.GetWeeklyUnitsWithTasksAndKcs(User.InstructorId(), learnerId, courseId, DateTime.SpecifyKind(weekEnd, DateTimeKind.Utc));
        return CreateResponse(result);
    }

    [HttpGet("feedback")]
    public ActionResult<List<UnitProgressRatingDto>> GetLearnerFeedback([FromQuery] int[]? unitIds, [FromQuery] DateTime weekEnd)
    {
        var result = _monitoringService.GetRecentRatingsForUnits(User.InstructorId(), unitIds, DateTime.SpecifyKind(weekEnd, DateTimeKind.Utc));
        return CreateResponse(result);
    }
}