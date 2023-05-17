using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.Domain.KnowledgeAnalysis;
using Tutor.Core.UseCases.KnowledgeAnalysis;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Analytics;

namespace Tutor.Web.Controllers.Instructors.Analytics;

[Authorize(Policy = "instructorPolicy")]
[Route("api/analytics/{kcId:int}/assessments")]
public class AssessmentAnalysisController : BaseApiController
{
    private readonly IAssessmentAnalysisService _assessmentAnalysisService;

    public AssessmentAnalysisController(IAssessmentAnalysisService assessmentAnalysisService, IMapper mapper) : base(mapper)
    {
        _assessmentAnalysisService = assessmentAnalysisService;
    }

    [HttpGet]
    public ActionResult<List<AiStatisticsDto>> GetStatistics(int kcId)
    {
        var result = _assessmentAnalysisService.GetStatistics(kcId, User.InstructorId());
        return CreateResponse<AiStatistics, AiStatisticsDto>(result);
    }

    [HttpGet("groups/{groupId:int}/")]
    public ActionResult<List<AiStatisticsDto>> GetAiStatisticsForGroup(int kcId, int groupId)
    {
        var result = _assessmentAnalysisService.GetStatisticsForGroup(kcId, groupId, User.InstructorId());
        return CreateResponse<AiStatistics, AiStatisticsDto>(result);
    }
}