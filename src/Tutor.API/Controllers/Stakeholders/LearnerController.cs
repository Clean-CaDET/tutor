using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Stakeholders.API.Dtos;
using Tutor.Stakeholders.API.Interfaces;

namespace Tutor.API.Controllers.Stakeholders;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/learners")]
public class LearnerController : BaseApiController
{
    private readonly ILearnerService _learnerService;

    public LearnerController(ILearnerService learnerService)
    {
        _learnerService = learnerService;
    }

    [HttpGet]
    public ActionResult<PagedResult<StakeholderAccountDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _learnerService.GetPaged(page, pageSize);
        return CreateResponse(result);
    }

    // Post because of potential URL length limit violation with query params
    [HttpPost("selected")]
    public ActionResult<PagedResult<StakeholderAccountDto>> GetSelected([FromBody] string[] indexes)
    {
        var result = _learnerService.GetByIndexes(indexes);
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult<StakeholderAccountDto> Register([FromBody] StakeholderAccountDto stakeholderAccount)
    {
        var result = _learnerService.Register(stakeholderAccount);
        return CreateResponse(result);
    }

    [HttpPost("bulk")]
    public ActionResult<List<StakeholderAccountDto>> BulkRegister([FromBody] List<StakeholderAccountDto> stakeholderAccounts)
    {
        var result = _learnerService.BulkRegister(stakeholderAccounts);
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<StakeholderAccountDto> Update([FromBody] StakeholderAccountDto stakeholderAccount)
    {
        var result = _learnerService.Update(stakeholderAccount);
        return CreateResponse(result);
    }

    [HttpPatch("{id:int}/archive")]
    public ActionResult<StakeholderAccountDto> Archive(int id, [FromBody] bool archive)
    {
        var result = _learnerService.Archive(id, archive);
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _learnerService.Delete(id);
        return CreateResponse(result);
    }
}