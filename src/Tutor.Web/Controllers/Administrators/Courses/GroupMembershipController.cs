using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.UseCases.Management.Groups;
using Tutor.Web.Mappings.Stakeholders;

namespace Tutor.Web.Controllers.Administrators.Courses;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/groups/{groupId:int}/members")]
[ApiController]
public class GroupMembershipController : BaseApiController
{
    private readonly ILearnerGroupService _groupService;

    public GroupMembershipController(IMapper mapper, ILearnerGroupService groupService) : base(mapper)
    {
        _groupService = groupService;
    }

    [HttpGet]
    public ActionResult<PagedResult<StakeholderAccountDto>> GetMembers(int groupId, [FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _groupService.GetMembers(groupId, page, pageSize);
        return CreateResponse<Learner, StakeholderAccountDto>(result);
    }

    [HttpPost("bulk")]
    public ActionResult CreateMembers(int groupId, [FromBody] List<StakeholderAccountDto> stakeholderAccounts)
    {
        var result = _groupService.CreateMembers(groupId,
            stakeholderAccounts.Select(_mapper.Map<Learner>).ToList());
        return CreateResponse(result);
    }

    [HttpDelete("{learnerId:int}")]
    public ActionResult Delete(int groupId, int learnerId)
    {
        var result = _groupService.DeleteMember(groupId, learnerId);
        return CreateResponse(result);
    }
}