using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.DomainModel.AssessmentItems.Challenges;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.DomainOverlay;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.Challenges;
using Tutor.Web.Controllers.Users;

namespace Tutor.Web.Controllers.Learners.DomainOverlay
{
    [Route("api/plugin")]
    [ApiController]
    public class PluginController : ControllerBase
    {
        // Should be enhanced after 4.2022.
        private readonly ILearnerRepository _learnerRepository;
        private readonly IMapper _mapper;
        private readonly ILearnerAssessmentService _learnerAssessmentService;

        public PluginController(ILearnerRepository learnerRepository, IMapper mapper, ILearnerAssessmentService learnerAssessmentService)
        {
            _learnerRepository = learnerRepository;
            _mapper = mapper;
            _learnerAssessmentService = learnerAssessmentService;
        }

        [HttpPost("login")]
        public ActionResult<LearnerDto> LoginPlugin([FromBody] CredentialsDto credentials)
        {
            var learner = _learnerRepository.GetByIndex(credentials.Username);
            if (learner != null) return Ok(learner);
            return NotFound("Invalid index.");
        }

        [HttpPost("challenge")]
        public ActionResult<ChallengeEvaluationDto> SubmitChallenge(
            [FromBody] ChallengeSubmissionDto submission)
        {
            var result = _learnerAssessmentService.SubmitAssessmentItemAnswer(submission.LearnerId, submission.AssessmentItemId, _mapper.Map<ChallengeSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<ChallengeEvaluationDto>(result.Value));
        }

        [HttpPost("challenge/hints")]
        public void RequestHints([FromBody] ChallengeSubmissionDto submission)
        {
            _learnerAssessmentService.RecordHintRequest(submission.LearnerId, submission.AssessmentItemId);
        }

        [HttpPost("challenge/solution")]
        public void RequestSolution([FromBody] ChallengeSubmissionDto submission)
        {
            _learnerAssessmentService.RecordSolutionRequest(submission.LearnerId, submission.AssessmentItemId);
        }
    }
}
