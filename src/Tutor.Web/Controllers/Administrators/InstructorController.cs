using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Web.Mappings.Stakeholders;

namespace Tutor.Web.Controllers.Administrators;

[Authorize(Policy = "administratorPolicy")]
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
    public ActionResult<List<StakeholderAccountDto>> GetAll()
    {
        var result = _instructorService.GetAll();
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<StakeholderAccountDto>).ToList());
    }

    [HttpPost]
    public ActionResult<StakeholderAccountDto> Register([FromBody] StakeholderAccountDto stakeholderAccount)
    {
        var result = _instructorService.Register(_mapper.Map<Instructor>(stakeholderAccount), stakeholderAccount.Email, stakeholderAccount.Password);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<StakeholderAccountDto>(result.Value));
    }

    [HttpPut("{stakeholderId:int}")]
    public ActionResult Update([FromBody] StakeholderAccountDto stakeholderAccount)
    {
        var result = _instructorService.Update(_mapper.Map<Instructor>(stakeholderAccount));
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }

    [HttpDelete("{stakeholderId:int}")]
    public ActionResult Delete(int stakeholderId)
    {
        var result = _instructorService.Delete(stakeholderId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }
}