using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.LearningTasks.API.Dtos.LearningTasks;
using Tutor.LearningTasks.API.Public.Authoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Authoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/authoring/units/{unitId:int}/learning-tasks")]
public class LearningTaskController : BaseApiController
{
    private readonly ILearningTaskService _learningTaskService;

    public LearningTaskController(ILearningTaskService learningTaskService)
    {
        _learningTaskService = learningTaskService;
    }

    [HttpGet("{id:int}")]
    public ActionResult<LearningTaskDto> Get(int unitId, int id)
    {
        var result = _learningTaskService.Get(id, unitId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpGet]
    public ActionResult<LearningTaskDto> GetByUnit(int unitId)
    {
        var result = _learningTaskService.GetByUnit(unitId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult<LearningTaskDto> Create(int unitId, [FromBody] LearningTaskDto learningTask)
    {
        learningTask.UnitId = unitId;
        var result = _learningTaskService.Create(learningTask, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPost("clone")]
    public ActionResult<LearningTaskDto> Clone(int unitId, [FromBody] LearningTaskDto taskHeader)
    {
        taskHeader.UnitId = unitId;
        var result = _learningTaskService.Clone(taskHeader, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut]
    public ActionResult<LearningTaskDto> Update(int unitId, LearningTaskDto learningTask)
    {
        learningTask.UnitId = unitId;
        var result = _learningTaskService.Update(learningTask, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int unitId, int id)
    {
        var result = _learningTaskService.Delete(id, unitId, User.InstructorId());
        return CreateResponse(result);
    }
}
