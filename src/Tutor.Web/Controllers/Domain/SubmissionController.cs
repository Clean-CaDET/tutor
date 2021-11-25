using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTask;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.Challenge;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.MultiResponseQuestion;

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
        //TODO: Should segregate this so that each AE type has a single controller and package. Introducing a new widget would then entail adding a new package instead of changing existing code.
        [HttpPost("challenge")]
        public ActionResult<ChallengeEvaluationDTO> SubmitChallenge(
            [FromBody] ChallengeSubmissionDTO submission)
        {
            var result = _submissionService.EvaluateAndSaveSubmission(_mapper.Map<ChallengeSubmission>(submission));

            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<ChallengeEvaluationDTO>(result.Value));
        }

        [HttpPost("question")]
        public ActionResult<List<MRQItemEvaluationDTO>> SubmitQuestionAnswers(
            [FromBody] MRQSubmissionDTO submission)
        {
            var result = _submissionService.EvaluateAndSaveSubmission(_mapper.Map<MRQSubmission>(submission));

            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<MRQEvaluationDTO>(result.Value));
        }

        [HttpPost("arrange-task")]
        public ActionResult<List<ArrangeTaskContainerEvaluationDTO>> SubmitArrangeTask(
            [FromBody] ArrangeTaskSubmissionDTO submission)
        {
            var result = _submissionService.EvaluateAndSaveSubmission(_mapper.Map<ArrangeTaskSubmission>(submission));

            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<ArrangeTaskEvaluationDTO>(result.Value));
        }
    }
}