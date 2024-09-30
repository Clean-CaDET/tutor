using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Monitoring;
using Tutor.Courses.API.Public.Monitoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring/learners")]
public class WeeklyActivityController : BaseApiController
{
    private readonly IWeeklyActivityService _activityService;

    public WeeklyActivityController(IWeeklyActivityService activityService)
    {
        _activityService = activityService;
    }

    [HttpGet("{learnerId:int}")]
    public ActionResult<List<UnitHeaderDto>> GetWeeklyUnitsWithTasksAndKcs(int learnerId, [FromQuery] int courseId, [FromQuery] DateTime weekEnd)
    {
        var result = _activityService.GetWeeklyUnitsWithTasksAndKcs(User.InstructorId(), learnerId, courseId, DateTime.SpecifyKind(weekEnd, DateTimeKind.Utc));
        return CreateResponse(result);
    }

    [HttpPost("{learnerId:int}/statistics")]
    public ActionResult<List<UnitProgressStatisticsDto>> GetKcAndTaskProgressAndWarnings(int learnerId, [FromQuery] int[]? unitIds, [FromBody] int[] groupMemberIds)
    {
        var result = _activityService.GetKcAndTaskProgressAndWarnings(User.InstructorId(), unitIds, learnerId, groupMemberIds);
        return CreateResponse(result);
    }

    [HttpGet("ratings")]
    public ActionResult<List<UnitProgressRatingDto>> GetLearnerFeedback([FromQuery] int[]? unitIds, [FromQuery] DateTime weekEnd)
    {
        var result = _activityService.GetRecentRatingsForUnits(User.InstructorId(), unitIds, DateTime.SpecifyKind(weekEnd, DateTimeKind.Utc));
        return CreateResponse(result);
    }
}