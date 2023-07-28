using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.API.Interfaces.Analysis;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Analysis;

[Authorize(Policy = "instructorPolicy")]
[Route("api/analysis/knowledge-components/{kcId:int}")]
public class KnowledgeAnalysisController : BaseApiController
{
    private readonly IKnowledgeAnalysisService _kcAnalysisService;

    public KnowledgeAnalysisController(IKnowledgeAnalysisService kcAnalysisService)
    {
        _kcAnalysisService = kcAnalysisService;
    }

    [HttpGet]
    public ActionResult<KcStatisticsDto> GetStatistics(int kcId)
    {
        var result = _kcAnalysisService.GetStatistics(kcId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpGet("groups/{groupId:int}/")]
    public ActionResult<KcStatisticsDto> GetStatisticsForGroup(int kcId, int groupId)
    {
        var result = _kcAnalysisService.GetStatisticsForGroup(kcId, groupId, User.InstructorId());
        return CreateResponse(result);
    }
}