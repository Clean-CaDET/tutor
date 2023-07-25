using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;
using Tutor.KnowledgeComponents.API.Interfaces.Learning.Assessment;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Learning.Assessment;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/assessment-item/{itemId:int}/submissions")]
public class EvaluationController : BaseApiController
{
    private readonly IEvaluationService _assessmentEvaluationService;
    private readonly IHelpService _assessmentHelpService;

    public EvaluationController(IEvaluationService service, IHelpService assessmentHelpService)
    {
        _assessmentEvaluationService = service;
        _assessmentHelpService = assessmentHelpService;
    }

    [HttpPost]
    public ActionResult<FeedbackDto> SubmitAssessmentAnswer(int itemId, [FromBody] SubmissionDto submission)
    {
        var result = _assessmentEvaluationService.EvaluateAssessmentItemSubmission(itemId, submission, User.LearnerId());
        return CreateResponse(result);
    }

    // Should be moved into a standalone module
    [HttpPost("tutor-message")]
    public ActionResult SaveInstructorMessage([FromBody] InstructorMessageDto instructorMessageDto)
    {
        var result = _assessmentHelpService
            .RecordInstructorMessage(User.LearnerId(), instructorMessageDto.KcId, instructorMessageDto.Message);
        return CreateResponse(result);
    }
}