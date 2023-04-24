using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
using Tutor.Core.UseCases.Management.Knowledge;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Knowledge.DTOs.InstructionalItems;

namespace Tutor.Web.Controllers.Instructors.Authoring;

[Route("api/authoring/knowledge-components/{kcId:int}/instruction")]
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
        return CreateResponse<InstructionalItem, InstructionalItemDto>(result, Ok, CreateErrorResponse, _mapper);
    }

    [HttpPost]
    public ActionResult<List<InstructionalItemDto>> Create([FromBody] InstructionalItemDto instructionalItem)
    {
        var result = _instructionService.Create(_mapper.Map<InstructionalItem>(instructionalItem), User.InstructorId());
        // Dahomey library adds type disciminators to list items but not single items... Will migrate to System.Text.JSON soon.
        // Should migrate to CreateResponse after (currently, entity is mapped to dto, list is mapped to list, page is mapped to page) 
        return Ok(new List<InstructionalItemDto> { _mapper.Map<InstructionalItemDto>(result.Value) });
    }

    [HttpPut("{id:int}")]
    public ActionResult<List<InstructionalItemDto>> Update([FromBody] InstructionalItemDto instructionalItem)
    {
        var result = _instructionService.Update(_mapper.Map<InstructionalItem>(instructionalItem), User.InstructorId());
        // Dahomey library adds type disciminators to list items but not single items...
        // Should migrate to CreateResponse after (currently, entity is mapped to dto, list is mapped to list, page is mapped to page) 
        return Ok(new List<InstructionalItemDto> { _mapper.Map<InstructionalItemDto>(result.Value) });
    }

    [HttpPut("ordering")]
    public ActionResult UpdateOrdering(int kcId, [FromBody] List<InstructionalItemDto> instructionalItems)
    {
        var result = _instructionService.UpdateOrdering(kcId, instructionalItems.Select(_mapper.Map<InstructionalItem>).ToList(), User.InstructorId());
        return CreateResponse<InstructionalItem, InstructionalItemDto>(result, Ok, CreateErrorResponse, _mapper);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int kcId, int id)
    {
        var result = _instructionService.Delete(id, kcId, User.InstructorId());
        return CreateResponse(result, Ok, CreateErrorResponse);
    }
}