using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;
using Tutor.Elaborations.API.Public.Authoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Authoring.Elaboration;

[Authorize(Policy = "instructorPolicy")]
[Route("api/authoring/units/{unitId:int}/concept-elaborations")]
public class ConceptElaborationTaskController : BaseApiController
{
    private readonly IConceptElaborationTaskService _service;

    public ConceptElaborationTaskController(IConceptElaborationTaskService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<ConceptElaborationTaskSummaryDto>> GetByUnit(int unitId)
    {
        var result = _service.GetByUnit(unitId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpGet("{id:int}")]
    public ActionResult<ConceptElaborationTaskDto> Get(int unitId, int id)
    {
        var result = _service.Get(id, unitId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult<ConceptElaborationTaskDto> Create(int unitId, [FromBody] ConceptElaborationTaskDto dto)
    {
        dto.UnitId = unitId;
        var result = _service.Create(dto, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<ConceptElaborationTaskDto> Update(int unitId, int id, [FromBody] ConceptElaborationTaskDto dto)
    {
        dto.Id = id;
        dto.UnitId = unitId;
        var result = _service.Update(dto, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int unitId, int id)
    {
        var result = _service.Delete(id, unitId, User.InstructorId());
        return CreateResponse(result);
    }
}
