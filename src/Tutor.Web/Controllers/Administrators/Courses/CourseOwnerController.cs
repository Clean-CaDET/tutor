using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Web.Mappings.Stakeholders;

namespace Tutor.Web.Controllers.Administrators.Courses;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/courses/{courseId:int}/owners")]
public class CourseOwnerController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly ICourseOwnershipService _ownershipService;

    public CourseOwnerController(IMapper mapper, ICourseOwnershipService ownershipService)
    {
        _mapper = mapper;
        _ownershipService = ownershipService;
    }

    [HttpGet]
    public ActionResult<List<StakeholderAccountDto>> GetAll(int courseId)
    {
        var result = _ownershipService.GetOwners(courseId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<StakeholderAccountDto>).ToList());
    }

    [HttpPost]
    public ActionResult Create(int courseId, [FromBody] int instructorId)
    {
        var result = _ownershipService.AssignOwnership(courseId, instructorId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }

    [HttpDelete("{instructorId:int}")]
    public ActionResult Delete(int courseId, int instructorId)
    {
        var result = _ownershipService.RemoveOwnership(courseId, instructorId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }
}