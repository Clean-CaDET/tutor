﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Web.Mappings.Stakeholders;

namespace Tutor.Web.Controllers.Administrators;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/learners")]
public class LearnerController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly ILearnerService _learnerService;

    public LearnerController(IMapper mapper, ILearnerService learnerService)
    {
        _mapper = mapper;
        _learnerService = learnerService;
    }

    [HttpGet]
    public ActionResult<PagedResult<StakeholderAccountDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _learnerService.GetPaged(page, pageSize);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);

        var items = result.Value.Results.Select(_mapper.Map<StakeholderAccountDto>).ToList();
        return Ok(new PagedResult<StakeholderAccountDto>(items, result.Value.TotalCount));
    }

    [HttpPost]
    public ActionResult<StakeholderAccountDto> Register([FromBody] StakeholderAccountDto stakeholderAccount)
    {
        var result = _learnerService.Register(_mapper.Map<Learner>(stakeholderAccount), stakeholderAccount.Index, stakeholderAccount.Password);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<StakeholderAccountDto>(result.Value));
    }

    [HttpPut("{stakeholderId:int}")]
    public ActionResult Update([FromBody] StakeholderAccountDto stakeholderAccount)
    {
        var result = _learnerService.Update(_mapper.Map<Learner>(stakeholderAccount));
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }

    [HttpDelete("{stakeholderId:int}")]
    public ActionResult Delete(int stakeholderId)
    {
        var result = _learnerService.Delete(stakeholderId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }
}