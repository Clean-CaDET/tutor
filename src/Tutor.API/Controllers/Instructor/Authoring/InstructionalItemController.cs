using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;
using Tutor.KnowledgeComponents.API.Public.Authoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Authoring;

[Route("api/authoring/knowledge-components/{kcId:int}/instruction")]
[Authorize(Policy = "instructorPolicy")]
public class InstructionalItemController : BaseApiController
{
    private readonly IInstructionalItemsService _instructionService;

    public InstructionalItemController(IInstructionalItemsService instructionService)
    {
        _instructionService = instructionService;
    }

    [HttpGet]
    public ActionResult<List<InstructionalItemDto>> GetForKc(int kcId)
    {
        var result = _instructionService.GetByKc(kcId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult<List<InstructionalItemDto>> Create([FromBody] InstructionalItemDto item)
    {
        var result = _instructionService.Create(item, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<List<InstructionalItemDto>> Update([FromBody] InstructionalItemDto item)
    {
        var result = _instructionService.Update(item, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut("ordering")]
    public ActionResult UpdateOrdering([FromBody] List<InstructionalItemDto> items)
    {
        var result = _instructionService.UpdateOrdering(items, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int kcId, int id)
    {
        var result = _instructionService.Delete(id, kcId, User.InstructorId());
        return CreateResponse(result);
    }
}