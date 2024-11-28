using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Public.Monitoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring/courses")]
public class CourseMonitoringController : BaseApiController
{
    private readonly ICourseMonitoringService _monitoringService;

    public CourseMonitoringController(ICourseMonitoringService monitoringService)
    {
        _monitoringService = monitoringService;
    }

    [HttpGet]
    public ActionResult<List<CourseDto>> GetActiveCourses()
    {
        var result = _monitoringService.GetOwnedActiveCourses(User.InstructorId());
        return CreateResponse(result);
    }

    [HttpGet("{courseId:int}")]
    public ActionResult<List<GroupDto>> GetGroupOverview(int courseId)
    {
        var result = _monitoringService.GetOwnedGroupFeedback(courseId, User.InstructorId());
        return CreateResponse(result);
    }
}