using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Elaborations.API.Dtos.Conversations;
using Tutor.Elaborations.API.Public.Learning;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Learning.Elaboration;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning")]
public class ConversationController : BaseApiController
{
    private readonly IConversationService _conversationService;

    public ConversationController(IConversationService conversationService)
    {
        _conversationService = conversationService;
    }

    [HttpGet("units/{unitId:int}/elaboration-tasks")]
    public ActionResult<List<ElaborationTaskDto>> GetTasksForUnit(int unitId)
    {
        var result = _conversationService.GetTasksForUnit(unitId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpPost("elaboration-tasks/{taskId:int}/turns")]
    public async IAsyncEnumerable<string> SubmitTurn(int taskId,
        [FromBody] SubmitTurnRequestDto dto,
        [EnumeratorCancellation] CancellationToken ct)
    {
        await foreach (var token in _conversationService.SubmitTurnAsync(
            taskId, dto.Content, User.LearnerId(), ct))
        {
            yield return token;
        }
    }

    [HttpPost("elaboration-tasks/attempts/{attemptId:int}/abandon")]
    public ActionResult<ConversationAttemptDto> AbandonAttempt(int attemptId)
    {
        var result = _conversationService.AbandonAttempt(attemptId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpGet("elaboration-tasks/attempts/{attemptId:int}")]
    public ActionResult<ConversationAttemptDto> GetAttempt(int attemptId)
    {
        var result = _conversationService.GetAttempt(attemptId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpGet("elaboration-tasks/{taskId:int}/attempts")]
    public ActionResult<List<ConversationAttemptDto>> GetAttempts(int taskId)
    {
        var result = _conversationService.GetAttempts(taskId, User.LearnerId());
        return CreateResponse(result);
    }
}
