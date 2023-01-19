﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
using Tutor.Core.UseCases.Management.Knowledge;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Knowledge.DTOs.InstructionalItems;

namespace Tutor.Web.Controllers.Instructors.Authoring;

[Route("api/authoring/knowledge-components/{kcId}/instruction")]
[Authorize(Policy = "instructorPolicy")]
public class InstructionController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IInstructionService _instructionService;

    public InstructionController(IMapper mapper, IInstructionService instructionService)
    {
        _mapper = mapper;
        _instructionService = instructionService;
    }

    [HttpGet]
    public ActionResult<List<InstructionalItemDto>> GetForKc(int kcId)
    {
        var result = _instructionService.GetForKc(kcId, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<InstructionalItemDto>).ToList());
    }

    [HttpPost]
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
    }

    [HttpPut("ordering")]
    public ActionResult UpdateOrdering(int kcId, [FromBody] List<InstructionalItemDto> instructionalItems)
    {
        var result = _instructionService.UpdateOrdering(kcId, instructionalItems.Select(_mapper.Map<InstructionalItem>).ToList(), User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<InstructionalItemDto>).ToList());
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int kcId, int id)
    {
        var result = _instructionService.Delete(id, kcId, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }
}