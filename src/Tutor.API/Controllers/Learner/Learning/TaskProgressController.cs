using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;
using Tutor.LearningTasks.API.Dtos.LearningTaskProgress;
using Tutor.LearningTasks.API.Public.Learning;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Learning;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/units/{unitId:int}/learning-tasks/{taskId:int}")]
public class TaskProgressController : BaseApiController
{
    private readonly ITaskProgressService _taskProgressService;

    public TaskProgressController(ITaskProgressService taskProgressService)
    {
        _taskProgressService = taskProgressService;
    }

    [HttpGet("/progress")]
    public ActionResult<List<InstructionalItemDto>> GetOrCreate(int unitId, int taskId)
    {
        var result = _taskProgressService.GetOrCreate(unitId, taskId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpPut("/progress/{id:int}/step/{stepId:int}")]
    public ActionResult<List<InstructionalItemDto>> ViewStep(int unitId, int id, int stepId)
    {
        var result = _taskProgressService.ViewStep(unitId, id, stepId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpPost("/progress/{id:int}/step")]
    public ActionResult<List<InstructionalItemDto>> SubmitAnswer(int unitId, int id, [FromBody] StepProgressDto stepProgress)
    {
        var result = _taskProgressService.SubmitAnswer(unitId, id, stepProgress, User.LearnerId());
        return CreateResponse(result);
    }
}
