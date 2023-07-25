using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Interfaces.Learning;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Learning;

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
        return CreateResponse(result);
    }

    [HttpPost("terminate")]
    public ActionResult TerminateSession(int knowledgeComponentId)
    {
        var result = _sessionService.TerminateSession(knowledgeComponentId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpPost("pause")]
    public ActionResult Pause(int knowledgeComponentId)
    {
        var result = _sessionService.PauseSession(knowledgeComponentId, User.LearnerId());
        return CreateResponse(result);
    }
    
    [HttpPost("continue")]
    public ActionResult TerminatePause(int knowledgeComponentId)
    {
        var result = _sessionService.ContinueSession(knowledgeComponentId, User.LearnerId());
        return CreateResponse(result);
    }
    
    [HttpPost("abandon")]
    public ActionResult AbandonSession(int knowledgeComponentId)
    {
        var result = _sessionService.AbandonSession(knowledgeComponentId, User.LearnerId());
        return CreateResponse(result);
    }
}