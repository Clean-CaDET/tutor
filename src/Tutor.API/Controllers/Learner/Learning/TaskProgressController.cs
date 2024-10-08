﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;
using Tutor.LearningTasks.API.Dtos.TaskProgress;
using Tutor.LearningTasks.API.Public.Learning;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Learning;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/units/{unitId:int}/learning-tasks/{taskId:int}/progress")]
public class TaskProgressController : BaseApiController
{
    private readonly ITaskProgressService _taskProgressService;

    public TaskProgressController(ITaskProgressService taskProgressService)
    {
        _taskProgressService = taskProgressService;
    }

    [HttpGet]
    public ActionResult<List<InstructionalItemDto>> GetOrCreate(int unitId, int taskId)
    {
        var result = _taskProgressService.GetOrCreate(unitId, taskId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpPut("{id:int}/step/{stepId:int}")]
    public ActionResult<List<InstructionalItemDto>> ViewStep(int unitId, int id, int stepId)
    {
        var result = _taskProgressService.ViewStep(unitId, id, stepId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpPost("{id:int}/step")]
    public ActionResult<List<InstructionalItemDto>> SubmitAnswer(int unitId, int id, [FromBody] StepProgressDto stepProgress)
    {
        var result = _taskProgressService.SubmitAnswer(unitId, id, stepProgress, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpPost("{id:int}/step/{stepId:int}/open-submission")]
    public ActionResult OpenSubmission(int unitId, int id, int stepId)
    {
        var result = _taskProgressService.OpenSubmission(unitId, id, stepId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpPost("{id:int}/step/{stepId:int}/open-guidance")]
    public ActionResult OpenGuidance(int unitId, int id, int stepId)
    {
        var result = _taskProgressService.OpenGuidance(unitId, id, stepId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpPost("{id:int}/step/{stepId:int}/open-example")]
    public ActionResult OpenExample(int unitId, int id, int stepId)
    {
        var result = _taskProgressService.OpenExample(unitId, id, stepId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpPost("{id:int}/step/{stepId:int}/play-video")]
    public ActionResult PlayExampleVideo(int unitId, int id, int stepId, [FromQuery] string videoUrl)
    {
        var result = _taskProgressService.PlayExampleVideo(unitId, id, stepId, User.LearnerId(), videoUrl);
        return CreateResponse(result);
    }

    [HttpPost("{id:int}/step/{stepId:int}/pause-video")]
    public ActionResult PauseExampleVideo(int unitId, int id, int stepId, [FromQuery] string videoUrl)
    {
        var result = _taskProgressService.PauseExampleVideo(unitId, id, stepId, User.LearnerId(), videoUrl);
        return CreateResponse(result);
    }

    [HttpPost("{id:int}/step/{stepId:int}/finish-video")]
    public ActionResult FinishExampleVideo(int unitId, int id, int stepId, [FromQuery] string videoUrl)
    {
        var result = _taskProgressService.FinishExampleVideo(unitId, id, stepId, User.LearnerId(), videoUrl);
        return CreateResponse(result);
    }
}
