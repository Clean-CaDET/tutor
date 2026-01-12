using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Tutor.KnowledgeComponents.API.Dtos.Chat;
using Tutor.KnowledgeComponents.API.Public.Learning;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Learning;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/knowledge-component/{knowledgeComponentId:int}/chat")]
public class KcChatController : BaseApiController
{
    private readonly IKcChatbotService _chatbotService;

    public KcChatController(IKcChatbotService chatbotService)
    {
        _chatbotService = chatbotService;
    }

    [HttpPost]
    public async IAsyncEnumerable<string> AskQuestion(int knowledgeComponentId, [FromBody] ChatQuestionDto question, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var token in _chatbotService.AskQuestionAsync(knowledgeComponentId, User.LearnerId(), question.Message, cancellationToken))
        {
            yield return token;
        }
    }
}
