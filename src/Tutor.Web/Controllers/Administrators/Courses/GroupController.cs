using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.UseCases.Management.Enrollments;
using Tutor.Web.Mappings.Enrollments;

namespace Tutor.Web.Controllers.Administrators.Courses;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/courses/{courseId:int}/groups")]
public class GroupController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly ILearnerGroupService _groupService;

    public GroupController(IMapper mapper, ILearnerGroupService groupService)
    {
        _mapper = mapper;
        _groupService = groupService;
    }

    [HttpGet]
    public ActionResult<List<GroupDto>> GetAll(int courseId)
    {
        var result = _groupService.GetByCourse(courseId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);

        var items = result.Value.Select(_mapper.Map<GroupDto>).ToList();
        return Ok(new PagedResult<GroupDto>(items, items.Count));
    }

    [HttpPost]
    public ActionResult<GroupDto> Create(int courseId, [FromBody] GroupDto group)
    {
        group.CourseId = courseId;
        var result = _groupService.Create(_mapper.Map<LearnerGroup>(group));
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<GroupDto>(result.Value));
    }

    [HttpPut("{groupId:int}")]
    public ActionResult<GroupDto> Update([FromBody] GroupDto group)
    {
        var result = _groupService.Update(_mapper.Map<LearnerGroup>(group));
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<GroupDto>(result.Value));
    }

    [HttpDelete("{groupId:int}")]
    public ActionResult Delete(int groupId)
    {
        var result = _groupService.Delete(groupId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }
}