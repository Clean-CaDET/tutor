using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.UseCases.Learning;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Tutor.Web.Mappings.Knowledge.DTOs.InstructionalItems;
using Tutor.Web.Mappings.KnowledgeMastery;

namespace Tutor.Web.Controllers.Learners.Learning;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning")]
public class StructureController : BaseApiController
{
    private readonly IStructureService _learningStructureService;
    public StructureController(IMapper mapper, IStructureService learningStructureService) : base(mapper)
    {
        _learningStructureService = learningStructureService;
    }

    [HttpGet("units/{courseId:int}/mastered")]
    public ActionResult<List<int>> GetMasteredUnitIds(int courseId)
    {
        var result = _learningStructureService.GetMasteredUnitIds(courseId, User.LearnerId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value);
    }

    [HttpGet("units/{unitId:int}")]
    public ActionResult<KnowledgeUnitDto> GetUnit(int unitId)
    {
        var result = _learningStructureService.GetUnit(unitId, User.LearnerId());
        return CreateResponse<KnowledgeUnit, KnowledgeUnitDto>(result);
    }

    [HttpGet("units/{unitId:int}/masteries")]
    public ActionResult<List<KnowledgeComponentMasteryDto>> GetMasteries(int unitId)
    {
        var result = _learningStructureService.GetMasteries(unitId, User.LearnerId());
        return CreateResponse<KnowledgeComponentMastery, KnowledgeComponentMasteryDto>(result);
    }

    [HttpGet("knowledge-component/{knowledgeComponentId:int}/")]
    public ActionResult<KnowledgeComponentDto> GetKnowledgeComponent(int knowledgeComponentId)
    {
        var result = _learningStructureService.GetKnowledgeComponent(knowledgeComponentId, User.LearnerId());
        return CreateResponse<KnowledgeComponent, KnowledgeComponentDto>(result);
    }

    [HttpGet("knowledge-component/{knowledgeComponentId:int}/instructional-items/")]
    public ActionResult<List<InstructionalItemDto>> GetInstructionalItems(int knowledgeComponentId)
    {
        var result = _learningStructureService.GetInstructionalItems(knowledgeComponentId, User.LearnerId());
        return CreateResponse<InstructionalItem, InstructionalItemDto>(result);
    }
}