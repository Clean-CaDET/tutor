using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges;
using Tutor.Core.UseCases.Learning.Assessment;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.Challenges;

namespace Tutor.Web.Controllers.Learners.Learning.Assessment
{
    [Authorize(Policy = "learnerPolicy")]
    [Route("api/submissions/")]
    public class ChallengeEvaluationController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IEvaluationService _assessmentEvaluationService;

        public ChallengeEvaluationController(IMapper mapper, IEvaluationService service)
        {
            _mapper = mapper;
            _assessmentEvaluationService = service;
        }

        [HttpPost("challenge")]
        public ActionResult<ChallengeEvaluationDto> SubmitChallenge(
            [FromBody] ChallengeSubmissionDto submission)
        {
            var result = _assessmentEvaluationService.EvaluateAssessmentItemSubmission(submission.LearnerId, submission.AssessmentItemId, _mapper.Map<ChallengeSubmission>(submission));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<ChallengeEvaluationDto>(result.Value));
        }
    }
}