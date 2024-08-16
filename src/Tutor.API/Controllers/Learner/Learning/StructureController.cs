using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge;
using Tutor.KnowledgeComponents.API.Public.Learning;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Learning;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning")]
public class StructureController : BaseApiController
{
    private readonly IStructureService _structureService;

    public StructureController(IStructureService structureService)
    {
        _structureService = structureService;
    }

    [HttpGet("units/{unitId:int}/masteries")]
    public ActionResult<List<KcWithMasteryDto>> GetKcsWithMasteries(int unitId)
    {
        var result = _structureService.GetKcsWithMasteries(unitId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpGet("knowledge-component/{knowledgeComponentId:int}/")]
    public ActionResult<KnowledgeComponentDto> GetKnowledgeComponent(int knowledgeComponentId)
    {
        var result = _structureService.GetKnowledgeComponent(knowledgeComponentId, User.LearnerId());
        return CreateResponse(result);
    }
}