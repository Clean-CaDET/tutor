using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions;
using Tutor.Core.DomainModel.AssessmentEvents.ShortAnswerQuestions;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTask;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.Challenge;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.MultiResponseQuestion;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ShortAnswerQuestion;

namespace Tutor.Web.Controllers.Domain
{
    [Route("api/submissions/")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISubmissionService _submissionService;

        public SubmissionController(IMapper mapper, ISubmissionService service)
        {
            _mapper = mapper;
            _submissionService = service;
        }
        
        [HttpPost("challenge")]
        public ActionResult<ChallengeEvaluationDto> SubmitChallenge(
            [FromBody] ChallengeSubmissionDto submission)
        {
            var result = _submissionService.EvaluateAndSaveSubmission(_mapper.Map<ChallengeSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<ChallengeEvaluationDto>(result.Value));
        }

        [HttpPost("question")]
        public ActionResult<List<MrqItemEvaluationDto>> SubmitMultipleResponseQuestion(
            [FromBody] MrqSubmissionDto submission)
        {
            var result = _submissionService.EvaluateAndSaveSubmission(_mapper.Map<MrqSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<MrqEvaluationDto>(result.Value));
        }

        [HttpPost("arrange-task")]
        public ActionResult<List<ArrangeTaskContainerEvaluationDto>> SubmitArrangeTask(
            [FromBody] ArrangeTaskSubmissionDto submission)
        {
            var result = _submissionService.EvaluateAndSaveSubmission(_mapper.Map<ArrangeTaskSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<ArrangeTaskEvaluationDto>(result.Value));
        }

        [HttpPost("short-answer")]
        public ActionResult<List<ArrangeTaskContainerEvaluationDto>> SubmitShortAnswerQuestion(
            [FromBody] SaqSubmissionDto submission)
        {
            var result = _submissionService.EvaluateAndSaveSubmission(_mapper.Map<SaqSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<SaqEvaluationDto>(result.Value));
        }
    }
}