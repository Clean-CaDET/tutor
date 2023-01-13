using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.UseCases.Management.Enrollments;
using Tutor.Web.Mappings.Stakeholders;

namespace Tutor.Web.Controllers.Administrators.Courses;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/groups/{groupId:int}/members")]
[ApiController]
public class GroupMembershipController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly ILearnerGroupService _groupService;

    public GroupMembershipController(IMapper mapper, ILearnerGroupService groupService)
    {
        _mapper = mapper;
        _groupService = groupService;
    }

    [HttpGet]
    public ActionResult<List<StakeholderAccountDto>> GetMembers(int groupId)
    {
        var result = _groupService.GetMembers(groupId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        var retVal = new PagedResult<StakeholderAccountDto>(
            result.Value.Select(_mapper.Map<StakeholderAccountDto>).ToList(), result.Value.Count);
        return Ok(retVal);
    }

    [HttpPost("bulk")]
    public ActionResult CreateMembers(int groupId, [FromBody] List<StakeholderAccountDto> stakeholderAccounts)
    {
        var result = _groupService.CreateMembers(groupId,
            stakeholderAccounts.Select(_mapper.Map<Learner>).ToList());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }

    [HttpDelete("{learnerId:int}")]
    public ActionResult Delete(int groupId, int learnerId)
    {
        var result = _groupService.DeleteMember(groupId, learnerId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }
}