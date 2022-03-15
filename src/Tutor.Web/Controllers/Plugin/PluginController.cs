using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.DomainModel.KnowledgeComponents.AssessmentEventHelp;
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
        private readonly IAssessmentEventHelpService _interactionService;

        public PluginController(ILearnerRepository learnerRepository, IMapper mapper, ISubmissionService submissionService, IAssessmentEventHelpService interactionService)
        {
            _learnerRepository = learnerRepository;
            _mapper = mapper;
            _submissionService = submissionService;
            _interactionService = interactionService;
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
            _interactionService.SeekHelp(submission.LearnerId, submission.AssessmentEventId, "ChallengeHints");
        }

        [HttpPost("challenge/solution")]
        public void SeekSolution([FromBody] ChallengeSubmissionDto submission)
        {
            _interactionService.SeekHelp(submission.LearnerId, submission.AssessmentEventId, "ChallengeSolution");
        }
    }
}
