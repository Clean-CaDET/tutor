using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Monitoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring")]
public class GroupMonitoringController : BaseApiController
{
    private readonly IGroupMonitoringService _groupMonitoringService;

    public GroupMonitoringController(IGroupMonitoringService groupMonitoringService)
    {
        _groupMonitoringService = groupMonitoringService;
    }

    [HttpGet("{courseId:int}/groups")]
    public ActionResult<PagedResult<GroupDto>> GetCourseGroups(int courseId, [FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _groupMonitoringService.GetByCourse(User.InstructorId(), courseId, page, pageSize);
        return CreateResponse(result);
    }

    [HttpGet("{courseId:int}/groups/{groupId:int}")]
    public ActionResult<PagedResult<LearnerDto>> GetGroupLearners(int courseId, int groupId, [FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _groupMonitoringService.GetLearners(User.InstructorId(), courseId, groupId, page, pageSize);
        return CreateResponse(result);
    }
}