using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.UseCases.Learning;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.KnowledgeMastery;

namespace Tutor.Web.Controllers.Learners.Learning;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/statistics/")]
public class StatisticsController : BaseApiController
{
    private readonly IStatisticsService _learningStatisticsService;

    public StatisticsController(IMapper mapper, IStatisticsService learningStatisticsService) : base(mapper)
    {
        _learningStatisticsService = learningStatisticsService;
    }

    [HttpGet("kcm/{knowledgeComponentId:int}")]
    public ActionResult<KcMasteryStatisticsDto> GetKcMasteryStatistics(int knowledgeComponentId)
    {
        var result = _learningStatisticsService.GetKcMasteryStatistics(knowledgeComponentId, User.LearnerId());
        return CreateResponse<KcMasteryStatistics, KcMasteryStatisticsDto>(result);
    }

    [HttpGet("aim/{assessmentItemId:int}")]
    public ActionResult<double> GetMaxCorrectness(int assessmentItemId)
    {
        var result = _learningStatisticsService.GetMaxAssessmentCorrectness(assessmentItemId, User.LearnerId());
        return CreateResponse(result);
    }
}