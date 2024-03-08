using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.LearningTasks.API.Dtos.LearningTasks;
using Tutor.LearningTasks.API.Public.Authoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Authoring.LearningTasks;

[Authorize(Policy = "instructorPolicy")]
[Route("api/authoring/units/{unitId:int}/learning-tasks/{learningTaskId:int}/activities")]
public class ActivityController : BaseApiController
{
    private readonly IActivityService _activityService;

    public ActivityController(IActivityService activityService)
    {
        _activityService = activityService;
    }

    [HttpPost]
    public ActionResult<ActivityDto> Create(int unitId, int learningTaskId, [FromBody] ActivityDto activity)
    {
        activity.UnitId = unitId;
        var result = _activityService.Create(activity, learningTaskId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut]
    public ActionResult<ActivityDto> Update(int unitId, int learningTaskId, [FromBody] ActivityDto activity)
    {
        activity.UnitId = unitId;
        var result = _activityService.Update(activity, learningTaskId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int unitId, int learningTaskId, int id)
    {
        var result = _activityService.Delete(id, unitId, learningTaskId, User.InstructorId());
        return CreateResponse(result);
    }
}
