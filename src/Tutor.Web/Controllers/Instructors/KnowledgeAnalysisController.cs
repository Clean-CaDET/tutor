using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.UseCases.KnowledgeAnalysis;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Knowledge.DTOs;

namespace Tutor.Web.Controllers.Instructors;

[Authorize(Policy = "instructorPolicy")]
[Route("api/knowledge-analysis/{kcId:int}")]
public class KnowledgeAnalysisController : BaseApiController
{
    private readonly IUnitAnalysisService _unitAnalysisService;
    private readonly IMapper _mapper;

    public KnowledgeAnalysisController(IUnitAnalysisService unitAnalysisService, IMapper mapper)
    {
        _unitAnalysisService = unitAnalysisService;
        _mapper = mapper;
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
}