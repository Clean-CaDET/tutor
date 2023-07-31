using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge;
using Tutor.KnowledgeComponents.API.Public.Authoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Authoring;

[Route("api/authoring/knowledge-components")]
[Authorize(Policy = "instructorPolicy")]
public class KnowledgeComponentController : BaseApiController
{
    private readonly IKnowledgeComponentService _kcService;

    public KnowledgeComponentController(IKnowledgeComponentService kcService)
    {
        _kcService = kcService;
    }
    
    [HttpGet]
    public ActionResult<KnowledgeComponentDto> GetByUnit([FromQuery] int unitId)
    {
        var result = _kcService.GetByUnit(unitId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpGet("{id:int}")]
    public ActionResult<KnowledgeComponentDto> Get(int id)
    {
        var result = _kcService.Get(id, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult<KnowledgeComponentDto> Create([FromBody] KnowledgeComponentDto kc)
    {
        var result = _kcService.Create(kc, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<KnowledgeComponentDto> Update([FromBody] KnowledgeComponentDto kc)
    {
        var result = _kcService.Update(kc, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _kcService.Delete(id, User.InstructorId());
        return CreateResponse(result);
    }
}