using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Elaborations.API.Dtos.Conversations;
using Tutor.Elaborations.API.Public.Authoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Authoring.Elaboration;

[Authorize(Policy = "instructorPolicy")]
[Route("api/authoring/units/{unitId:int}/elaboration-tasks")]
public class ElaborationTaskController : BaseApiController
{
    private readonly IElaborationTaskService _elaborationTaskService;

    public ElaborationTaskController(IElaborationTaskService elaborationTaskService)
    {
        _elaborationTaskService = elaborationTaskService;
    }

    [HttpGet]
    public ActionResult<List<ElaborationTaskDto>> GetByUnit(int unitId)
    {
        var result = _elaborationTaskService.GetByUnit(unitId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult<ElaborationTaskDto> Create(int unitId, [FromBody] ElaborationTaskDto dto)
    {
        dto.UnitId = unitId;
        var result = _elaborationTaskService.Create(dto, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<ElaborationTaskDto> Update(int unitId, int id, [FromBody] ElaborationTaskDto dto)
    {
        dto.Id = id;
        dto.UnitId = unitId;
        var result = _elaborationTaskService.Update(dto, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int unitId, int id)
    {
        var result = _elaborationTaskService.Delete(id, unitId, User.InstructorId());
        return CreateResponse(result);
    }
}
