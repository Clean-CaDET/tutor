﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.API.Public.Analysis;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Analysis;

[Authorize(Policy = "instructorPolicy")]
[Route("api/analysis/units/{unitId:int}")]
public class UnitAnalysisController : BaseApiController
{
    private readonly IMisconceptionAnalysisService _misconceptionService;

    public UnitAnalysisController(IMisconceptionAnalysisService misconceptionService)
    {
        _misconceptionService = misconceptionService;
    }

    [HttpGet]
    public ActionResult<List<AiStatisticsDto>> GetTop10MisconceivedAssessments(int unitId)
    {
        var result = _misconceptionService.GetTop10MisconceivedAssessments(unitId, User.InstructorId());
        return CreateResponse(result);
    }
}