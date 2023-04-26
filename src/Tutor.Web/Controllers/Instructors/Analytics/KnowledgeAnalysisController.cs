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
    private readonly IKnowledgeAnalysisService _kcAnalysisService;
    private readonly IMapper _mapper;

    public KnowledgeAnalysisController(IKnowledgeAnalysisService kcAnalysisService, IMapper mapper)
    {
        _kcAnalysisService = kcAnalysisService;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<KcStatisticsDto> GetStatistics(int kcId)
    {
        var result = _kcAnalysisService.GetStatistics(kcId, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<KcStatisticsDto>(result.Value));
    }

    [HttpGet("groups/{groupId:int}/")]
    public ActionResult<KcStatisticsDto> GetStatisticsForGroup(int kcId, int groupId)
    {
        var result = _kcAnalysisService.GetStatisticsForGroup(kcId, groupId, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<KcStatisticsDto>(result.Value));
    }
}