using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos.Reflections;
using Tutor.Courses.API.Public.Authoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Authoring;

[Route("api/authoring/units/{unitId:int}/reflections")]
[Authorize(Policy = "instructorPolicy")]
public class ReflectionController : BaseApiController
{
    private readonly IReflectionAuthoringService _reflectionService;

    public ReflectionController(IReflectionAuthoringService reflectionService)
    {
        _reflectionService = reflectionService;
    }

    [HttpGet]
    public ActionResult<List<ReflectionDto>> GetByUnit(int unitId)
    {
        var result = _reflectionService.GetByUnit(unitId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult<ReflectionDto> Create(int unitId, [FromBody] ReflectionDto reflection)
    {
        reflection.UnitId = unitId;
        var result = _reflectionService.Create(reflection, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<ReflectionDto> Update(int unitId, [FromBody] ReflectionDto reflection)
    {
        reflection.UnitId = unitId;
        var result = _reflectionService.Update(reflection, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _reflectionService.Delete(id, User.InstructorId());
        return CreateResponse(result);
    }
}