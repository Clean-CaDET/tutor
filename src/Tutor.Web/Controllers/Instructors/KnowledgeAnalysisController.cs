using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.UseCases.KnowledgeAnalysis;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Knowledge.DTOs;

namespace Tutor.Web.Controllers.Instructors;

[Authorize(Policy = "instructorPolicy")]
[Route("api/knowledge-analysis/{unitId:int}")]
public class KnowledgeAnalysisController : BaseApiController
{
    private readonly IUnitAnalysisService _unitAnalysisService;

    public KnowledgeAnalysisController(IUnitAnalysisService unitAnalysisService, IMapper mapper) : base(mapper)
    {
        _unitAnalysisService = unitAnalysisService;
    }

    [HttpGet]
    public ActionResult<List<KcStatisticsDto>> GetKcStatistics(int unitId)
    {
        var result = _unitAnalysisService.GetKnowledgeComponentsStats(unitId, User.InstructorId());
        return CreateResponse<KcStatistics, KcStatisticsDto>(result);
    }

    [HttpGet("groups/{groupId:int}/")]
    public ActionResult<List<KcStatisticsDto>> GetKcStatisticsForGroup(int unitId, int groupId)
    {
        var result = _unitAnalysisService.GetKnowledgeComponentsStatsForGroup(unitId, groupId, User.InstructorId());
        return CreateResponse<KcStatistics, KcStatisticsDto>(result);
    }
}