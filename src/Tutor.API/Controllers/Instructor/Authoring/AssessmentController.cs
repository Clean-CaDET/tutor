﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Public.Authoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Authoring;

[Route("api/authoring/knowledge-components/{kcId:int}/assessments")]
[Authorize(Policy = "instructorPolicy")]
public class AssessmentController : BaseApiController
{
    private readonly IAssessmentService _assessmentService;

    public AssessmentController(IAssessmentService assessmentService)
    {
        _assessmentService = assessmentService;
    }

    [HttpGet]
    public ActionResult<List<AssessmentItemDto>> GetForKc(int kcId)
    {
        var result = _assessmentService.GetByKc(kcId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult<AssessmentItemDto> Create([FromBody] AssessmentItemDto item)
    {
        var result = _assessmentService.Create(item, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<AssessmentItemDto> Update([FromBody] AssessmentItemDto item)
    {
        var result = _assessmentService.Update(item, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut("ordering")]
    public ActionResult<List<AssessmentItemDto>> UpdateOrdering([FromBody] List<AssessmentItemDto> items)
    {
        var result = _assessmentService.UpdateOrdering(items, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int kcId, int id)
    {
        var result = _assessmentService.Delete(id, kcId, User.InstructorId());
        return CreateResponse(result);
    }
}