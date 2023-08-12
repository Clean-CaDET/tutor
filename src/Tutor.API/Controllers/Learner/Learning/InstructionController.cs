using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;
using Tutor.KnowledgeComponents.API.Public.Learning;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Learning;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning")]
public class InstructionController : BaseApiController
{
    private readonly IInstructionService _instructionService;
    public InstructionController(IInstructionService instructionService)
    {
        _instructionService = instructionService;
    }

    [HttpGet("knowledge-component/{knowledgeComponentId:int}/instructional-items/")]
    public ActionResult<List<InstructionalItemDto>> GetInstructionalItems(int knowledgeComponentId)
    {
        var result = _instructionService.GetByKc(knowledgeComponentId, User.LearnerId());
        return CreateResponse(result);
    }
}