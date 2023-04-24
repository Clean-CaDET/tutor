using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.UseCases.Learning;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Web.Controllers.Learners.Learning;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/session/{knowledgeComponentId:int}")]
public class SessionController : BaseApiController
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }
        
    [HttpPost("launch")]
    public ActionResult LaunchSession(int knowledgeComponentId)
    {
        var result = _sessionService.LaunchSession(knowledgeComponentId, User.LearnerId());
        return CreateResponse(result, Ok, CreateErrorResponse);
    }

    [HttpPost("terminate")]
    public ActionResult TerminateSession(int knowledgeComponentId)
    {
        var result = _sessionService.TerminateSession(knowledgeComponentId, User.LearnerId());
        return CreateResponse(result, Ok, CreateErrorResponse);
    }
}