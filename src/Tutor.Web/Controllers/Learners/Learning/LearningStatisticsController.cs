using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.UseCases.Learning;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.KnowledgeMastery;

namespace Tutor.Web.Controllers.Learners.Learning
{
    [Authorize(Policy = "learnerPolicy")]
    [Route("api/knowledge-components/")]
    [ApiController]
    public class LearningStatisticsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStatisticsService _learningStatisticsService;

        public LearningStatisticsController(IMapper mapper, IStatisticsService learningStatisticsService)
        {
            _mapper = mapper;
            _learningStatisticsService = learningStatisticsService;
        }

        [HttpGet("kcm-statistics/{knowledgeComponentId:int}")]
        public ActionResult<KcMasteryStatisticsDto> GetKcMasteryStatistics(int knowledgeComponentId)
        {
            var result = _learningStatisticsService.GetKcMasteryStatistics(knowledgeComponentId, User.LearnerId());
            if (result.IsSuccess) return Ok(_mapper.Map<KcMasteryStatisticsDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpGet("aim-correctness/{assessmentItemId:int}")]
        public ActionResult<double> GetMaxCorrectness(int assessmentItemId)
        {
            var result = _learningStatisticsService.GetMaxAssessmentCorrectness(User.LearnerId(), assessmentItemId);
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(result.Value);
        }
    }
}