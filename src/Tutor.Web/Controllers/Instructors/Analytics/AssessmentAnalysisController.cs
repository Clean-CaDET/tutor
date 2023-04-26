using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.UseCases.KnowledgeAnalysis;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Analytics;

namespace Tutor.Web.Controllers.Instructors.Analytics;

[Authorize(Policy = "instructorPolicy")]
[Route("api/analytics/{kcId:int}/assessments")]
public class AssessmentAnalysisController : BaseApiController
{
    private readonly IAssessmentAnalysisService _assessmentAnalysisService;
    private readonly IMapper _mapper;

    public AssessmentAnalysisController(IAssessmentAnalysisService assessmentAnalysisService, IMapper mapper)
    {
        _mapper = mapper;
        _assessmentAnalysisService = assessmentAnalysisService;
    }

    [HttpGet]
    public ActionResult<List<AiStatisticsDto>> GetStatistics(int kcId)
    {
        var result = _assessmentAnalysisService.GetStatistics(kcId, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<AiStatisticsDto>).ToList());
    }

    [HttpGet("groups/{groupId:int}/")]
    public ActionResult<List<AiStatisticsDto>> GetAiStatisticsForGroup(int kcId, int groupId)
    {
        var result = _assessmentAnalysisService.GetStatisticsForGroup(kcId, groupId, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<AiStatisticsDto>).ToList());
    }
}