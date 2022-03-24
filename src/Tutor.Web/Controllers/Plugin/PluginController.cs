using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.LearnerModel;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.Challenge;
using Tutor.Web.Controllers.Learners.DTOs;

namespace Tutor.Web.Controllers.Plugin
{
    [Route("api/plugin")]
    [ApiController]
    public class PluginController : ControllerBase
    {
        // Should be enhanced after 4.2022.
        private readonly ILearnerRepository _learnerRepository;
        private readonly IMapper _mapper;
        private readonly ISubmissionService _submissionService;
        private readonly IAssessmentEventHelpService _aeHelpService;

        public PluginController(ILearnerRepository learnerRepository, IMapper mapper, ISubmissionService submissionService, IAssessmentEventHelpService aeHelpService)
        {
            _learnerRepository = learnerRepository;
            _mapper = mapper;
            _submissionService = submissionService;
            _aeHelpService = aeHelpService;
        }

        [HttpPost("login")]
        public ActionResult<LearnerDto> LoginPlugin([FromBody] LoginDto login)
        {
            var learner = _learnerRepository.GetByIndex(login.StudentIndex);
            if (learner != null) return Ok(learner);
            return NotFound("Invalid index.");
        }

        [HttpPost("challenge")]
        public ActionResult<ChallengeEvaluationDto> SubmitChallenge(
            [FromBody] ChallengeSubmissionDto submission)
        {
            var result = _submissionService.EvaluateAndSaveSubmission(_mapper.Map<ChallengeSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<ChallengeEvaluationDto>(result.Value));
        }

        [HttpPost("challenge/hints")]
        public void SeekHints([FromBody] ChallengeSubmissionDto submission)
        {
            _aeHelpService.SeekChallengeHints(submission.LearnerId, submission.AssessmentEventId);
        }

        [HttpPost("challenge/solution")]
        public void SeekSolution([FromBody] ChallengeSubmissionDto submission)
        {
            _aeHelpService.SeekChallengeSolution(submission.LearnerId, submission.AssessmentEventId);
        }
    }
}
