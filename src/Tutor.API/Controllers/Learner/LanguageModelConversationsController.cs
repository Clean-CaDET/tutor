using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.API.Interfaces;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner;

[Authorize(Policy = "learnerPolicy")]
[Route("api/lm-conversations")]
[ApiController]
public class LanguageModelConversationsController : BaseApiController
{
    private readonly IConversationService _conversationService;

    public LanguageModelConversationsController(IConversationService conversationService)
    {
        _conversationService = conversationService;
    }

    [HttpGet("{contextGroup:int}/{contextId:int}")]
    public ActionResult<ConversationDto> GetByContext(int contextGroup, int contextId)
    {
        var result = _conversationService.GetByContext(contextGroup, contextId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponseDto>> SendMessage([FromBody] MessageRequestDto messageRequest)
    {
        var result = await _conversationService.SendMessageAsync(messageRequest, User.LearnerId());
        return CreateResponse(result);
    }
}
