using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.UseCases.Management.Knowledge;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems;

namespace Tutor.Web.Controllers.Instructors.Authoring;

[Route("api/authoring/knowledge-components/{kcId:int}/assessments")]
[Authorize(Policy = "instructorPolicy")]
public class AssessmentController : BaseApiController
{
    private readonly IAssessmentService _assessmentService;

    public AssessmentController(IMapper mapper, IAssessmentService assessmentService) : base(mapper)
    {
        _assessmentService = assessmentService;
    }

    [HttpGet]
    public ActionResult<List<AssessmentItemDto>> GetForKc(int kcId)
    {
        var result = _assessmentService.GetForKc(kcId, User.InstructorId());
        return CreateResponse<AssessmentItem, AssessmentItemDto>(result);
    }

    [HttpPost]
    public ActionResult<AssessmentItemDto> Create([FromBody] AssessmentItemDto items)
    {
        var result = _assessmentService.Create(_mapper.Map<AssessmentItem>(items), User.InstructorId());
        return CreateResponse<AssessmentItem, AssessmentItemDto>(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<AssessmentItemDto> Update([FromBody] AssessmentItemDto items)
    {
        var result = _assessmentService.Update(_mapper.Map<AssessmentItem>(items), User.InstructorId());
        return CreateResponse<AssessmentItem, AssessmentItemDto>(result);
    }

    [HttpPut("ordering")]
    public ActionResult<List<AssessmentItemDto>> UpdateOrdering(int kcId, [FromBody] List<AssessmentItemDto> items)
    {
        var result = _assessmentService.UpdateOrdering(kcId, items.Select(_mapper.Map<AssessmentItem>).ToList(), User.InstructorId());
        return CreateResponse<AssessmentItem, AssessmentItemDto>(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int kcId, int id)
    {
        var result = _assessmentService.Delete(id, kcId, User.InstructorId());
        return CreateResponse(result);
    }
}