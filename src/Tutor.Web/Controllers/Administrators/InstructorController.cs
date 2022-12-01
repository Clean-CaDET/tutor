using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.UseCases.Management.Stakeholder;
using Tutor.Web.Mappings.Stakeholders;

namespace Tutor.Web.Controllers.Administrators;

[Route("api/management/instructors")]
public class InstructorController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IInstructorService _instructorService;

    public InstructorController(IMapper mapper, IInstructorService instructorService)
    {
        _mapper = mapper;
        _instructorService = instructorService;
    }

    [HttpGet]
    public ActionResult<List<InstructorDto>> GetAll()
    {
        var result = _instructorService.GetAll();
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<InstructorDto>).ToList());
    }

    [HttpPost]
    public ActionResult<InstructorDto> Create([FromBody] InstructorDto instructor)
    {
        var result = _instructorService.Create(_mapper.Map<Instructor>(instructor));
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<InstructorDto>(result.Value));
    }

    [HttpPut("{instructorId:int}")]
    public ActionResult Update([FromBody] InstructorDto instructor)
    {
        var result = _instructorService.Update(_mapper.Map<Instructor>(instructor));
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }

    [HttpDelete("{instructorId:int}")]
    public ActionResult Delete(int instructorId)
    {
        var result = _instructorService.Delete(instructorId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }
}