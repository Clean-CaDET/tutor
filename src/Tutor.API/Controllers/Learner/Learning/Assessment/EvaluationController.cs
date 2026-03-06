using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Public.Learning.Assessment;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Learning.Assessment;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/assessment-item/{itemId:int}/submissions")]
public class EvaluationController : BaseApiController
{
    private readonly IEvaluationService _assessmentEvaluationService;

    public EvaluationController(IEvaluationService service)
    {
        _assessmentEvaluationService = service;
    }

    [HttpPost]
    public ActionResult<FeedbackDto> SubmitAssessmentAnswer(int itemId, [FromBody] SubmissionDto submission)
    {
        var result = _assessmentEvaluationService.EvaluateAssessmentItemSubmission(itemId, submission, User.LearnerId());
        return CreateResponse(result);
    }
}