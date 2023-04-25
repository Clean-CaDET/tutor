using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Web.Mappings.Stakeholders;

namespace Tutor.Web.Controllers.Administrators.Courses;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/courses/{courseId:int}/owners")]
public class CourseOwnerController : BaseApiController
{
    private readonly ICourseOwnershipService _ownershipService;

    public CourseOwnerController(IMapper mapper, ICourseOwnershipService ownershipService) : base(mapper)
    {
        _ownershipService = ownershipService;
    }

    [HttpGet]
    public ActionResult<List<StakeholderAccountDto>> GetAll(int courseId)
    {
        var result = _ownershipService.GetOwners(courseId);
        return CreateResponse<Instructor, StakeholderAccountDto>(result);
    }

    [HttpPost]
    public ActionResult Create(int courseId, [FromBody] int instructorId)
    {
        var result = _ownershipService.AssignOwnership(courseId, instructorId);
        return CreateResponse(result);
    }

    [HttpDelete("{instructorId:int}")]
    public ActionResult Delete(int courseId, int instructorId)
    {
        var result = _ownershipService.RemoveOwnership(courseId, instructorId);
        return CreateResponse(result);
    }
}