using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Elaborations.API.Dtos.ConceptRecords;
using Tutor.Elaborations.API.Public.Authoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Authoring.Elaboration;

[Authorize(Policy = "instructorPolicy")]
[Route("api/authoring/courses/{courseId:int}/concept-records")]
public class ConceptRecordController : BaseApiController
{
    private readonly IConceptRecordService _conceptRecordService;

    public ConceptRecordController(IConceptRecordService conceptRecordService)
    {
        _conceptRecordService = conceptRecordService;
    }

    [HttpGet]
    public ActionResult<List<ConceptRecordDto>> GetByCourse(int courseId)
    {
        var result = _conceptRecordService.GetByCourse(courseId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpGet("{id:int}")]
    public ActionResult<ConceptRecordDto> Get(int courseId, int id)
    {
        var result = _conceptRecordService.Get(id, courseId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult<ConceptRecordDto> Create(int courseId, [FromBody] ConceptRecordDto dto)
    {
        dto.CourseId = courseId;
        var result = _conceptRecordService.Create(dto, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<ConceptRecordDto> Update(int courseId, int id, [FromBody] ConceptRecordDto dto)
    {
        dto.Id = id;
        dto.CourseId = courseId;
        var result = _conceptRecordService.Update(dto, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int courseId, int id)
    {
        var result = _conceptRecordService.Delete(id, courseId, User.InstructorId());
        return CreateResponse(result);
    }
}
