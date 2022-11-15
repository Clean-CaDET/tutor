using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.UseCases.KnowledgeAnalysis;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Analytics;

namespace Tutor.Web.Controllers.Instructors;

[Authorize(Policy = "instructorPolicy")]
[Route("api/instructors/knowledge-analysis/")]
[ApiController]
public class KnowledgeAnalysisController : ControllerBase
{
    private readonly IUnitAnalysisService _unitAnalysisService;
    private readonly IMapper _mapper;

    public KnowledgeAnalysisController(IUnitAnalysisService unitAnalysisService, IMapper mapper)
    {
        _unitAnalysisService = unitAnalysisService;
        _mapper = mapper;
    }

    [HttpGet("{unitId:int}/groups/")]
    public ActionResult<List<KcStatisticsDto>> GetKcStatistics(int unitId)
    {
        var result = _unitAnalysisService.GetKnowledgeComponentsStats(unitId, User.InstructorId());
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<KcStatisticsDto>).ToList());
    }

    [HttpGet("{unitId:int}/groups/{groupId:int}/")]
    public ActionResult<List<KcStatisticsDto>> GetKcStatisticsForGroup(int unitId, int groupId)
    {
        var result = _unitAnalysisService.GetKnowledgeComponentsStatsForGroup(unitId, groupId, User.InstructorId());
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<KcStatisticsDto>).ToList());
    }
}