using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentItems.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentItems.Challenges;
using Tutor.Core.DomainModel.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.DomainModel.AssessmentItems.ShortAnswerQuestions;
using Tutor.Core.LearnerModel.DomainOverlay;
using Tutor.Infrastructure.Security.Authorization.JWT;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.ArrangeTasks;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.Challenges;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.MultiResponseQuestions;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.ShortAnswerQuestions;
using Tutor.Web.Controllers.Learners.DomainOverlay.DTOs;

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
            var result = _learnerAssessmentService.EvaluateAndSaveSubmission(_mapper.Map<ChallengeSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<ChallengeEvaluationDto>(result.Value));
        }

        [HttpPost("question")]
        public ActionResult<List<MrqItemEvaluationDto>> SubmitMultipleResponseQuestion(
            [FromBody] MrqSubmissionDto submission)
        {
            var result = _learnerAssessmentService.EvaluateAndSaveSubmission(_mapper.Map<MrqSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<MrqEvaluationDto>(result.Value));
        }

        [HttpPost("arrange-task")]
        public ActionResult<List<AtContainerEvaluationDto>> SubmitArrangeTask(
            [FromBody] AtSubmissionDto submission)
        {
            var result = _learnerAssessmentService.EvaluateAndSaveSubmission(_mapper.Map<ArrangeTaskSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<AtEvaluationDto>(result.Value));
        }

        [HttpPost("short-answer")]
        public ActionResult<List<SaqEvaluationDto>> SubmitShortAnswerQuestion(
            [FromBody] SaqSubmissionDto submission)
        {
            var result = _learnerAssessmentService.EvaluateAndSaveSubmission(_mapper.Map<SaqSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<SaqEvaluationDto>(result.Value));
        }

        // Rework when we separate the controllers and AEMastery.
        [HttpPost("max-correctness")]
        public ActionResult<double> GetMaxCorrectness([FromBody] ChallengeSubmissionDto submission)
        {
            var result = _learnerAssessmentService.GetMaxSubmissionCorrectness(submission.AssessmentItemId, submission.LearnerId);
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(result.Value);
        }
        
        // Should be moved into a standalone module
        [HttpPost("tutor-message")]
        public ActionResult SaveInstructorMessage([FromBody] InstructorMessageDto instructorMessageDto)
        {
            var result = _learnerAssessmentService
                .SaveInstructorMessage(instructorMessageDto.Message, instructorMessageDto.KcId, User.Id());
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok();
        }
    }
}