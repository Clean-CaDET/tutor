using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.AssessmentItems.ArrangeTasks;
using Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges;
using Tutor.Core.Domain.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.Domain.Knowledge.AssessmentItems.ShortAnswerQuestions;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.ArrangeTasks;
using Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.Challenges;
using Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.MultiChoiceQuestions;
using Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.MultiResponseQuestions;
using Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.ShortAnswerQuestions;
using Tutor.Web.Mappings.Mastery;
using Tutor.Core.UseCases.Learning.Assessment;

namespace Tutor.Web.Controllers.Learners.DomainOverlay
{
    [Authorize(Policy = "learnerPolicy")]
    [Route("api/submissions/")]
    [ApiController]
    public class AssessmentEvaluationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEvaluationService _assessmentEvaluationService;
        private readonly IHelpService _assessmentHelpService;

        public AssessmentEvaluationController(IMapper mapper, IEvaluationService service, IHelpService assessmentHelpService)
        {
            _mapper = mapper;
            _assessmentEvaluationService = service;
            _assessmentHelpService = assessmentHelpService;
        }
        
        [HttpPost("challenge")]
        public ActionResult<ChallengeEvaluationDto> SubmitChallenge(
            [FromBody] ChallengeSubmissionDto submission)
        {
            var result = _assessmentEvaluationService.EvaluateAssessmentItemSubmission(submission.LearnerId, submission.AssessmentItemId, _mapper.Map<ChallengeSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<ChallengeEvaluationDto>(result.Value));
        }

        [HttpPost("question")]
        public ActionResult<List<MrqItemEvaluationDto>> SubmitMultipleResponseQuestion(
            [FromBody] MrqSubmissionDto submission)
        {
            var result = _assessmentEvaluationService.EvaluateAssessmentItemSubmission(User.LearnerId(), submission.AssessmentItemId, _mapper.Map<MrqSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<MrqEvaluationDto>(result.Value));
        }

        [HttpPost("multiple-choice-question")]
        public ActionResult<McqEvaluationDto> SubmitMultiChoiceQuestion(
            [FromBody] McqSubmissionDto submission)
        {
            var result = _assessmentEvaluationService.EvaluateAssessmentItemSubmission(User.LearnerId(), submission.AssessmentItemId, _mapper.Map<McqSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<McqEvaluationDto>(result.Value));
        }

        [HttpPost("arrange-task")]
        public ActionResult<List<AtContainerEvaluationDto>> SubmitArrangeTask(
            [FromBody] AtSubmissionDto submission)
        {
            var result = _assessmentEvaluationService.EvaluateAssessmentItemSubmission(User.LearnerId(), submission.AssessmentItemId, _mapper.Map<ArrangeTaskSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<AtEvaluationDto>(result.Value));
        }

        [HttpPost("short-answer")]
        public ActionResult<List<SaqEvaluationDto>> SubmitShortAnswerQuestion(
            [FromBody] SaqSubmissionDto submission)
        {
            var result = _assessmentEvaluationService.EvaluateAssessmentItemSubmission(User.LearnerId(), submission.AssessmentItemId, _mapper.Map<SaqSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<SaqEvaluationDto>(result.Value));
        }

        // Rework when we separate the controllers and AEMastery.
        [HttpPost("max-correctness")]
        public ActionResult<double> GetMaxCorrectness([FromBody] ChallengeSubmissionDto submission)
        {
            var result = _assessmentEvaluationService.GetMaxCorrectness(User.LearnerId(), submission.AssessmentItemId);
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(result.Value);
        }
        
        // Should be moved into a standalone module
        [HttpPost("tutor-message")]
        public ActionResult SaveInstructorMessage([FromBody] InstructorMessageDto instructorMessageDto)
        {
            var result = _assessmentHelpService
                .RecordInstructorMessage(User.LearnerId(), instructorMessageDto.KcId, instructorMessageDto.Message);
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok();
        }
    }
}