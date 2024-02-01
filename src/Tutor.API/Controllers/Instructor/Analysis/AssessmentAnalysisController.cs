using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.API.Public.Analysis;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Analysis;

[Authorize(Policy = "instructorPolicy")]
[Route("api/analysis/knowledge-components/{kcId:int}/assessments")]
public class AssessmentAnalysisController : BaseApiController
{
    private readonly IAssessmentAnalysisService _assessmentAnalysisService;

    public AssessmentAnalysisController(IAssessmentAnalysisService assessmentAnalysisService)
    {
        _assessmentAnalysisService = assessmentAnalysisService;
    }

    [HttpGet]
    public ActionResult<List<AiStatisticsDto>> GetStatistics(int kcId)
    {
        var result = _assessmentAnalysisService.GetStatistics(kcId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpGet("{aiId:int}")]
    public ActionResult<List<SubmissionCountDto>> GetCommonIncorrectSubmissions(int kcId, int aiId)
    {
        var result = _assessmentAnalysisService.Get5MostFrequentWrongSubmissions(kcId, aiId, User.InstructorId());
        return CreateResponse(result);
    }
}