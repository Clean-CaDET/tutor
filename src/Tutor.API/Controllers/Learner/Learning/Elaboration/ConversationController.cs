using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;
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

    [HttpGet("units/{unitId:int}/concept-elaborations")]
    public ActionResult<List<ConceptElaborationTaskSummaryDto>> GetTasksForUnit(int unitId)
    {
        var result = _conversationService.GetTasksForUnit(unitId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpGet("concept-elaborations/{taskId:int}")]
    public ActionResult<ConceptElaborationTaskDto> GetTaskDetail(int taskId)
    {
        var result = _conversationService.GetTaskDetail(taskId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpPost("concept-elaborations/{taskId:int}/conversations")]
    public async IAsyncEnumerable<string> StartConversation(int taskId,
        [FromBody] SubmitTurnRequestDto dto,
        [EnumeratorCancellation] CancellationToken ct)
    {
        await foreach (var token in _conversationService.StartConversationAsync(
            taskId, dto.Content, User.LearnerId(), ct))
        {
            yield return token;
        }
    }

    [HttpPost("concept-elaborations/attempts/{attemptId:int}/turns")]
    public async IAsyncEnumerable<string> SubmitTurn(int attemptId,
        [FromBody] SubmitTurnRequestDto dto,
        [EnumeratorCancellation] CancellationToken ct)
    {
        await foreach (var token in _conversationService.SubmitTurnAsync(
            attemptId, dto.Content, User.LearnerId(), ct))
        {
            yield return token;
        }
    }

    [HttpPost("concept-elaborations/attempts/{attemptId:int}/abandon")]
    public ActionResult<ConversationAttemptDto> AbandonAttempt(int attemptId)
    {
        var result = _conversationService.AbandonAttempt(attemptId, User.LearnerId());
        return CreateResponse(result);
    }
}
