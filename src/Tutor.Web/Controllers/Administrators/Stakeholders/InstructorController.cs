using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Web.Mappings.Stakeholders;

namespace Tutor.Web.Controllers.Administrators.Stakeholders;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/instructors")]
public class InstructorController : BaseApiController
{
    private readonly IInstructorService _instructorService;

    public InstructorController(IMapper mapper, IInstructorService instructorService) : base(mapper)
    {
        _instructorService = instructorService;
    }

    [HttpGet]
    public ActionResult<PagedResult<StakeholderAccountDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _instructorService.GetPaged(page, pageSize);
        return CreateResponse<Instructor, StakeholderAccountDto>(result);
    }

    [HttpPost]
    public ActionResult<StakeholderAccountDto> Register([FromBody] StakeholderAccountDto stakeholderAccount)
    {
        var result = _instructorService.Register(_mapper.Map<Instructor>(stakeholderAccount), stakeholderAccount.Email, stakeholderAccount.Password, "Instructor");
        return CreateResponse<Instructor, StakeholderAccountDto>(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<StakeholderAccountDto> Update([FromBody] StakeholderAccountDto stakeholderAccount)
    {
        var result = _instructorService.Update(_mapper.Map<Instructor>(stakeholderAccount));
        return CreateResponse<Instructor, StakeholderAccountDto>(result);
    }

    [HttpPatch("{id:int}/archive")]
    public ActionResult<StakeholderAccountDto> Archive(int id, [FromBody] bool archive)
    {
        var result = _instructorService.Archive(id, archive);
        return CreateResponse<Instructor, StakeholderAccountDto>(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _instructorService.Delete(id);
        return CreateResponse(result);
    }
}