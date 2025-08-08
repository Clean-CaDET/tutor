using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.LearningTasks.API.Public.Learning;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Learning;

[Authorize(Policy = "learnerPolicy")]
[Route("api/tasks/{taskId:int}/conversations")]
public class TaskConversationController : BaseApiController
{
    private readonly ITaskConversationService _conversationService;

    public TaskConversationController(ITaskConversationService conversationService)
    {
        _conversationService = conversationService;
    }

    [HttpGet("recent")]
    public ActionResult GetMostRecentConversation(int taskId)
    {
        var result = _conversationService.GetMostRecentConversation(taskId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpPost]
    public async Task<ActionResult> StartNewConversation(int taskId, [FromBody] string message)
    {
        var result = await _conversationService.StartNewConversation(taskId, User.LearnerId(), message);
        return CreateResponse(result);
    }

    [HttpPost("{conversationId:int}")]
    public async Task<ActionResult> ContinueConversation(int conversationId, [FromBody] string message)
    {
        var result = await _conversationService.ContinueConversation(conversationId, User.LearnerId(), message);
        return CreateResponse(result);
    }
}