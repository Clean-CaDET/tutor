using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentItems.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentItems.Challenges;
using Tutor.Core.DomainModel.AssessmentItems.MultiChoiceQuestions;
using Tutor.Core.DomainModel.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.DomainModel.AssessmentItems.ShortAnswerQuestions;
using Tutor.Core.LearnerModel.DomainOverlay;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.ArrangeTasks;
using Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.Challenges;
using Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.MultiChoiceQuestions;
using Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.MultiResponseQuestions;
using Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.ShortAnswerQuestions;
using Tutor.Web.Mappings.Mastery;

namespace Tutor.Web.Controllers.Learners.DomainOverlay
{
    [Authorize(Policy = "learnerPolicy")]
    [Route("api/submissions/")]
    [ApiController]
    public class LearnerAssessmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILearnerAssessmentService _learnerAssessmentService;

        public LearnerAssessmentController(IMapper mapper, ILearnerAssessmentService service)
        {
            _mapper = mapper;
            _learnerAssessmentService = service;
        }
        
        [HttpPost("challenge")]
        public ActionResult<ChallengeEvaluationDto> SubmitChallenge(
            [FromBody] ChallengeSubmissionDto submission)
        {
            var result = _learnerAssessmentService.EvaluateAndSaveSubmission(submission.LearnerId, submission.AssessmentItemId, _mapper.Map<ChallengeSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<ChallengeEvaluationDto>(result.Value));
        }

        [HttpPost("question")]
        public ActionResult<List<MrqItemEvaluationDto>> SubmitMultipleResponseQuestion(
            [FromBody] MrqSubmissionDto submission)
        {
            var result = _learnerAssessmentService.EvaluateAndSaveSubmission(User.LearnerId(), submission.AssessmentItemId, _mapper.Map<MrqSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<MrqEvaluationDto>(result.Value));
        }

        [HttpPost("multiple-choice-question")]
        public ActionResult<McqEvaluationDto> SubmitMultiChoiceQuestion(
            [FromBody] McqSubmissionDto submission)
        {
            var result = _learnerAssessmentService.EvaluateAndSaveSubmission(User.LearnerId(), submission.AssessmentItemId, _mapper.Map<McqSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<McqEvaluationDto>(result.Value));
        }

        [HttpPost("arrange-task")]
        public ActionResult<List<AtContainerEvaluationDto>> SubmitArrangeTask(
            [FromBody] AtSubmissionDto submission)
        {
            var result = _learnerAssessmentService.EvaluateAndSaveSubmission(User.LearnerId(), submission.AssessmentItemId, _mapper.Map<ArrangeTaskSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<AtEvaluationDto>(result.Value));
        }

        [HttpPost("short-answer")]
        public ActionResult<List<SaqEvaluationDto>> SubmitShortAnswerQuestion(
            [FromBody] SaqSubmissionDto submission)
        {
            var result = _learnerAssessmentService.EvaluateAndSaveSubmission(User.LearnerId(), submission.AssessmentItemId, _mapper.Map<SaqSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<SaqEvaluationDto>(result.Value));
        }

        // Rework when we separate the controllers and AEMastery.
        [HttpPost("max-correctness")]
        public ActionResult<double> GetMaxCorrectness([FromBody] ChallengeSubmissionDto submission)
        {
            var result = _learnerAssessmentService.GetMaxCorrectness(User.LearnerId(), submission.AssessmentItemId);
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(result.Value);
        }
        
        // Should be moved into a standalone module
        [HttpPost("tutor-message")]
        public ActionResult SaveInstructorMessage([FromBody] InstructorMessageDto instructorMessageDto)
        {
            var result = _learnerAssessmentService
                .SaveInstructorMessage(User.LearnerId(), instructorMessageDto.KcId, instructorMessageDto.Message);
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok();
        }
    }
}