using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Interfaces.Management;
using Tutor.Stakeholders.API.Dtos;

namespace Tutor.API.Controllers.Administrator.Courses;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/groups/{groupId:int}/members")]
[ApiController]
public class GroupMembershipController : BaseApiController
{
    private readonly IGroupMembershipService _membershipService;

    public GroupMembershipController(IGroupMembershipService membershipService)
    {
        _membershipService = membershipService;
    }

    [HttpGet]
    public ActionResult<PagedResult<StakeholderAccountDto>> GetMembers(int groupId, [FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _membershipService.GetMembers(groupId, page, pageSize);
        return CreateResponse(result);
    }

    [HttpPost("bulk")]
    public ActionResult CreateMembers(int groupId, [FromBody] List<int> learnerIds)
    {
        var result = _membershipService.CreateMembers(groupId, learnerIds);
        return CreateResponse(result);
    }

    [HttpDelete("{learnerId:int}")]
    public ActionResult Delete(int groupId, int learnerId)
    {
        var result = _membershipService.DeleteMember(groupId, learnerId);
        return CreateResponse(result);
    }
}