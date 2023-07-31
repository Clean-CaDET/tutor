using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Management;

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
    public ActionResult<List<LearnerDto>> GetMembers(int groupId)
    {
        var result = _membershipService.GetMembers(groupId);
        var pagedResult = new PagedResult<LearnerDto>(result.Value, result.Value.Count).ToResult();
        return CreateResponse(pagedResult);
    }

    [HttpPost("bulk")]
    public ActionResult CreateMembers(int groupId, [FromBody] List<LearnerDto> learners)
    {
        var learnerIds = new List<int>();
        learners.ForEach(learner =>
        {
            learnerIds.Add(learner.Id);
        });
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