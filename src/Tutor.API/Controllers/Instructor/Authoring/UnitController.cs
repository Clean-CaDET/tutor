using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Authoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Authoring;

[Route("api/authoring/courses/{courseId:int}/units")]
[Authorize(Policy = "instructorPolicy")]
public class UnitController : BaseApiController
{
    private readonly IUnitService _unitService;

    public UnitController(IUnitService unitService)
    {
        _unitService = unitService;
    }

    [HttpPost]
    public ActionResult<KnowledgeUnitDto> Create(int courseId, [FromBody] KnowledgeUnitDto unit)
    {
        unit.CourseId = courseId;
        var result = _unitService.Create(unit, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<KnowledgeUnitDto> Update(int courseId, [FromBody] KnowledgeUnitDto unit)
    {
        unit.CourseId = courseId;
        // TODO: Reexamine this ID (also found in Admin group controller)
        var result = _unitService.Update(unit, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _unitService.Delete(id, User.InstructorId());
        return CreateResponse(result);
    }
}