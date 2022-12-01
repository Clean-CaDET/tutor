using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;
using Tutor.Core.UseCases.Learning.Assessment;
using Tutor.Web.Controllers.Users;
using Tutor.Web.Mappings.CourseIteration;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.Challenges;

namespace Tutor.Web.Controllers.Learners.Learning;

[Route("api/plugin")]
[ApiController]
public class PluginController : ControllerBase
{
    private readonly ILearnerRepository _learnerRepository;
    private readonly IMapper _mapper;
    private readonly IEvaluationService _assessmentEvaluationService;
    private readonly IHelpService _assessmentHelpService;

    public PluginController(ILearnerRepository learnerRepository, IMapper mapper, IEvaluationService assessmentEvaluationService, IHelpService assessmentHelpService)
    {
        _learnerRepository = learnerRepository;
        _mapper = mapper;
        _assessmentEvaluationService = assessmentEvaluationService;
        _assessmentHelpService = assessmentHelpService;
    }

    [HttpPost("login")]
    public ActionResult<LearnerDto> LoginPlugin([FromBody] CredentialsDto credentials)
    {
        //var learner = _learnerRepository.GetByIndex(credentials.Username);
        //if (learner != null) return Ok(learner);
        // Need to fix this if we plan to support it further.
        return NotFound("Invalid index.");
    }

    [HttpPost("challenge")]
    public ActionResult<ChallengeEvaluationDto> SubmitChallenge(
        [FromBody] ChallengeSubmissionDto submission)
    {
        var result = _assessmentEvaluationService.EvaluateAssessmentItemSubmission(submission.AssessmentItemId, _mapper.Map<ChallengeSubmission>(submission), submission.LearnerId);
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(_mapper.Map<ChallengeEvaluationDto>(result.Value));
    }

    [HttpPost("challenge/hints")]
    public void RequestHints([FromBody] ChallengeSubmissionDto submission)
    {
        _assessmentHelpService.RecordHintRequest(submission.LearnerId, submission.AssessmentItemId);
    }

    [HttpPost("challenge/solution")]
    public void RequestSolution([FromBody] ChallengeSubmissionDto submission)
    {
        _assessmentHelpService.RecordSolutionRequest(submission.LearnerId, submission.AssessmentItemId);
    }
}