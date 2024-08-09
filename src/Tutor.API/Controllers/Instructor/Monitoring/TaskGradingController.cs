using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.LearningTasks.API.Dtos.LearningTaskProgress;
using Tutor.LearningTasks.API.Dtos.LearningTasks;
using Tutor.LearningTasks.API.Public.Authoring;
using Tutor.LearningTasks.API.Public.Monitoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring/units/{unitId:int}/learning-tasks")]
public class TaskGradingController : BaseApiController
{
    private readonly ILearningTaskService _taskService;
    private readonly IGradingService _gradingService;

    public TaskGradingController(ILearningTaskService taskService, IGradingService gradingService)
    {
        _taskService = taskService;
        _gradingService = gradingService;
    }

    [HttpGet]
    public ActionResult<List<LearningTaskDto>> GetTasksByUnit(int unitId)
    {
        var result = _taskService.GetByUnit(unitId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpGet("learners/{learnerId:int}/progresses")]
    public ActionResult<List<TaskProgressDto>> GetByUnitAndLearner(int unitId, int learnerId)
    {
        var result = _gradingService.GetByUnitAndLearner(unitId, learnerId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut("progresses/{progressId:int}/steps")]
    public ActionResult<TaskProgressDto> SubmitGrade(int unitId, int progressId, [FromBody] StepProgressDto stepProgress)
    {
        var result = _gradingService.SubmitGrade(unitId, progressId, stepProgress, User.InstructorId());
        return CreateResponse(result);
    }
}
