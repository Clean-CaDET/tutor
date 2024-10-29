using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Public.Monitoring;

namespace Tutor.API.Controllers.Administrator;

[Authorize(Policy = "administratorPolicy")]
[Route("api/overview/courses/{courseId:int}")]
public class CourseMonitoringController : BaseApiController
{
    private readonly ICourseMonitoringService _monitoringService;

    public CourseMonitoringController(ICourseMonitoringService monitoringService)
    {
        _monitoringService = monitoringService;
    }

    [HttpGet]
    public ActionResult<List<GroupDto>> GetOverview(int courseId)
    {
        var result = _monitoringService.GetGroupedLearnerFeedback(courseId);
        return CreateResponse(result);
    }
}