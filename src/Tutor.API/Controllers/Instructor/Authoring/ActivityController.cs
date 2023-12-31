using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.LearningTasks.API.Dtos.Activities;
using Tutor.LearningTasks.API.Public.Authoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Authoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/authoring/courses/{courseId:int}/activities")]
public class ActivityController : BaseApiController
{
    private readonly IActivityService _activityService;

    public ActivityController(IActivityService activityService)
    {
        _activityService = activityService;
    }

    [HttpGet("{id:int}")]
    public ActionResult<ActivityDto> Get(int id)
    {
        var result = _activityService.GetWithExamples(id);
        if(result == null)
            return NotFound(result);
        return CreateResponse(result);
    }

    [HttpGet]
    public ActionResult<List<ActivityDto>> GetByCourse(int courseId)
    {
        var result = _activityService.GetWithExamplesByCourse(courseId);
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult<ActivityDto> Create(int courseId, [FromBody] ActivityDto activity)
    {
        activity.CourseId = courseId;
        var result = _activityService.Create(activity, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut]
    public ActionResult<ActivityDto> Update(int courseId, [FromBody] ActivityDto activity)
    {
        activity.CourseId = courseId;
        var result = _activityService.Update(activity, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int courseId, int id)
    {
        var result = _activityService.Delete(id, courseId, User.InstructorId());
        return CreateResponse(result);
    }
}
