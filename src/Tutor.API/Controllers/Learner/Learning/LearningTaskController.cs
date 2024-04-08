using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.LearningTasks.API.Dtos.LearningTasks;
using Tutor.LearningTasks.API.Public.Learning;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Learning;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/units/{unitId:int}/learning-tasks")]
public class LearningTaskController : BaseApiController
{
    private readonly ITaskService _taskService;

    public LearningTaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("{id:int}")]
    public ActionResult<LearningTaskDto> Get(int unitId, int id)
    {
        var result = _taskService.Get(id, unitId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpGet]
    public ActionResult<List<LearningTaskDto>> GetByUnit(int unitId)
    {
        var result = _taskService.GetByUnit(unitId, User.LearnerId());
        return CreateResponse(result);
    }
}
