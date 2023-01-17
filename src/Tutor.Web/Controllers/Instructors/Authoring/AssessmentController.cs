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
    private readonly IMapper _mapper;
    private readonly IAssessmentService _assessmentService;

    public AssessmentController(IMapper mapper, IAssessmentService assessmentService)
    {
        _mapper = mapper;
        _assessmentService = assessmentService;
    }

    [HttpGet]
    public ActionResult<List<AssessmentItemDto>> GetForKc(int kcId)
    {
        var result = _assessmentService.GetForKc(kcId, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<AssessmentItemDto>).ToList());
    }

    /*[HttpPost]
    public ActionResult<List<InstructionalItemDto>> Create([FromBody] InstructionalItemDto instructionalItem)
    {
        var result = _instructionService.Create(_mapper.Map<InstructionalItem>(instructionalItem), User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        // Dahomey library adds type disciminators to list items but not single items...
        return Ok(new List<InstructionalItemDto> { _mapper.Map<InstructionalItemDto>(result.Value) });
    }

    [HttpPut("{id:int}")]
    public ActionResult<List<InstructionalItemDto>> Update([FromBody] InstructionalItemDto instructionalItem)
    {
        var result = _instructionService.Update(_mapper.Map<InstructionalItem>(instructionalItem), User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        // Dahomey library adds type disciminators to list items but not single items...
        return Ok(new List<InstructionalItemDto> { _mapper.Map<InstructionalItemDto>(result.Value) });
    }*/

    [HttpPut("ordering")]
    public ActionResult<List<AssessmentItemDto>> UpdateOrdering(int kcId, [FromBody] List<AssessmentItemDto> assessmentItems)
    {
        var result = _assessmentService.UpdateOrdering(kcId, assessmentItems.Select(_mapper.Map<AssessmentItem>).ToList(), User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<AssessmentItemDto>).ToList());
    }

    /*[HttpDelete("{id:int}")]
    public ActionResult Delete(int kcId, int id)
    {
        var result = _instructionService.Delete(id, kcId, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }*/
}