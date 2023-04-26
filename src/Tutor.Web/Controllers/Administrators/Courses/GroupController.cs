using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.UseCases.Management.Groups;
using Tutor.Web.Mappings.Enrollments;

namespace Tutor.Web.Controllers.Administrators.Courses;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/courses/{courseId:int}/groups")]
public class GroupController : BaseApiController
{
    private readonly ILearnerGroupService _groupService;

    public GroupController(IMapper mapper, ILearnerGroupService groupService) : base(mapper)
    {
        _groupService = groupService;
    }

    [HttpGet]
    public ActionResult<PagedResult<GroupDto>> GetAll(int courseId, [FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _groupService.GetByCourse(courseId, page, pageSize);
        return CreateResponse<LearnerGroup, GroupDto>(result);
    }

    [HttpPost]
    public ActionResult<GroupDto> Create(int courseId, [FromBody] GroupDto group)
    {
        group.CourseId = courseId;
        var result = _groupService.Create(_mapper.Map<LearnerGroup>(group));
        return CreateResponse<LearnerGroup, GroupDto>(result);
    }

    [HttpPut("{groupId:int}")]
    public ActionResult<GroupDto> Update([FromBody] GroupDto group)
    {
        var result = _groupService.Update(_mapper.Map<LearnerGroup>(group));
        return CreateResponse<LearnerGroup, GroupDto>(result);
    }

    [HttpDelete("{groupId:int}")]
    public ActionResult Delete(int groupId)
    {
        var result = _groupService.Delete(groupId);
        return CreateResponse(result);
    }
}