using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.UseCases.Learning;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.KnowledgeMastery;

namespace Tutor.Web.Controllers.Learners.Learning
{
    [Authorize(Policy = "learnerPolicy")]
    [Route("api/learning/statistics/")]
    public class StatisticsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IStatisticsService _learningStatisticsService;

        public StatisticsController(IMapper mapper, IStatisticsService learningStatisticsService)
        {
            _mapper = mapper;
            _learningStatisticsService = learningStatisticsService;
        }

        [HttpGet("kcm/{knowledgeComponentId:int}")]
        public ActionResult<KcMasteryStatisticsDto> GetKcMasteryStatistics(int knowledgeComponentId)
        {
            var result = _learningStatisticsService.GetKcMasteryStatistics(knowledgeComponentId, User.LearnerId());
            if(result.IsFailed) CreateErrorResponse(result.Errors);
            return Ok(_mapper.Map<KcMasteryStatisticsDto>(result.Value));
        }

        [HttpGet("aim/{assessmentItemId:int}")]
        public ActionResult<double> GetMaxCorrectness(int assessmentItemId)
        {
            var result = _learningStatisticsService.GetMaxAssessmentCorrectness(assessmentItemId, User.LearnerId());
            if (result.IsFailed) CreateErrorResponse(result.Errors);
            return Ok(result.Value);
        }
    }
}