using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;
using Tutor.KnowledgeComponents.API.Interfaces.Learning;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Learning;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/statistics/")]
public class StatisticsController : BaseApiController
{
    private readonly IStatisticsService _statisticsService;

    public StatisticsController(IStatisticsService statisticsService)
    {
        _statisticsService = statisticsService;
    }

    [HttpGet("kcm/{knowledgeComponentId:int}")]
    public ActionResult<KcMasteryStatisticsDto> GetKcMasteryStatistics(int knowledgeComponentId)
    {
        var result = _statisticsService.GetKcMasteryStatistics(knowledgeComponentId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpGet("aim/{assessmentItemId:int}")]
    public ActionResult<double> GetMaxCorrectness(int assessmentItemId)
    {
        var result = _statisticsService.GetMaxAssessmentCorrectness(assessmentItemId, User.LearnerId());
        return CreateResponse(result);
    }
}