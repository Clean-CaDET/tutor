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

    [HttpGet("{contextId:int}")]
    public ActionResult<ConversationDto> Get(int contextId)
    {
        var result = _conversationService.Get(contextId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> SendMessage([FromBody] MessageRequest messageRequest)
    {
        var result = await _conversationService.SendMessage(messageRequest, User.LearnerId());
        return CreateResponse(result);
    }
}
