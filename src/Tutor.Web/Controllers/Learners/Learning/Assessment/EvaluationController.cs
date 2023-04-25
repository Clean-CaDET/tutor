using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.UseCases.Learning.Assessment;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems;
using Tutor.Web.Mappings.KnowledgeMastery;

namespace Tutor.Web.Controllers.Learners.Learning.Assessment;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/assessment-item/{assessmentItemId:int}/submissions")]
public class EvaluationController : BaseApiController
{
    private readonly IEvaluationService _assessmentEvaluationService;
    private readonly IHelpService _assessmentHelpService;

    public EvaluationController(IMapper mapper, IEvaluationService service, IHelpService assessmentHelpService) : base(mapper)
    {
        _assessmentEvaluationService = service;
        _assessmentHelpService = assessmentHelpService;
    }

    [HttpPost]
    public ActionResult<FeedbackDto> SubmitAssessmentAnswer(int assessmentItemId, [FromBody] SubmissionDto submission)
    {
        var result = _assessmentEvaluationService.EvaluateAssessmentItemSubmission(assessmentItemId, _mapper.Map<Submission>(submission), User.LearnerId());
        return CreateResponse<Feedback, FeedbackDto>(result);
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