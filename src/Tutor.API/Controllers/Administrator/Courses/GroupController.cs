using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Management;

namespace Tutor.API.Controllers.Administrator.Courses;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/courses/{courseId:int}/groups")]
public class GroupController : BaseApiController
{
    private readonly IGroupService _groupService;

    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet]
    public ActionResult<List<GroupDto>> GetAll(int courseId)
    {
        var result = _groupService.GetByCourse(courseId);
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult<GroupDto> Create(int courseId, [FromBody] GroupDto group)
    {
        group.CourseId = courseId;
        var result = _groupService.Create(group);
        return CreateResponse(result);
    }

    [HttpPut("{groupId:int}")]
    public ActionResult<GroupDto> Update([FromBody] GroupDto group)
    {
        var result = _groupService.Update(group);
        return CreateResponse(result);
    }

    [HttpDelete("{groupId:int}")]
    public ActionResult Delete(int groupId)
    {
        var result = _groupService.Delete(groupId);
        return CreateResponse(result);
    }
}