using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.UseCases.KnowledgeAnalysis;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Analytics;

namespace Tutor.Web.Controllers.Instructors.Analytics;

[Authorize(Policy = "instructorPolicy")]
[Route("api/analytics/{kcId:int}")]
public class KnowledgeAnalysisController : BaseApiController
{
    private readonly IUnitAnalysisService _unitAnalysisService;
    private readonly IAssessmentAnalysisService _assessmentAnalysisService;
    private readonly IMapper _mapper;

    public KnowledgeAnalysisController(IUnitAnalysisService unitAnalysisService,
        IAssessmentAnalysisService assessmentAnalysisService, IMapper mapper)
    {
        _unitAnalysisService = unitAnalysisService;
        _mapper = mapper;
        _assessmentAnalysisService = assessmentAnalysisService;
    }

    [HttpGet]
    public ActionResult<KcStatisticsDto> GetKcStatistics(int kcId)
    {
        var result = _unitAnalysisService.GetKcStatistics(kcId, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<KcStatisticsDto>(result.Value));
    }

    [HttpGet("groups/{groupId:int}/")]
    public ActionResult<KcStatisticsDto> GetKcStatisticsForGroup(int kcId, int groupId)
    {
        var result = _unitAnalysisService.GetKcStatisticsForGroup(kcId, groupId, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<KcStatisticsDto>(result.Value));
    }

    [HttpGet("assessments")]
    public ActionResult<List<AiStatisticsDto>> GetAiStatistics(int kcId)
    {
        var result = _assessmentAnalysisService.GetAiStatistics(kcId, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<AiStatisticsDto>));
    }

    [HttpGet("assessments/groups/{groupId:int}/")]
    public ActionResult<List<AiStatisticsDto>> GetAiStatisticsForGroup(int kcId, int groupId)
    {
        // Should segregate this class when we get a better understanding of the analytics we want.
        var result = _assessmentAnalysisService.GetAiStatisticsForGroup(kcId, groupId, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<AiStatisticsDto>));
    }
}