using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.UseCases.Management.Stakeholder;
using Tutor.Web.Mappings.Knowledge.DTOs;

namespace Tutor.Web.Controllers.Administrators;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/stakeholders/{personId:int}/ownerships")]
public class CourseOwnershipController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly ICourseOwnershipService _ownershipService;
    
    public CourseOwnershipController(IMapper mapper, ICourseOwnershipService ownershipService)
    {
        _mapper = mapper;
        _ownershipService = ownershipService;
    }

    [HttpGet]
    public ActionResult<List<CourseDto>> GetAll(int personId)
    {
        var result = _ownershipService.GetOwnedCourses(personId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<CourseDto>).ToList());
    }

    [HttpPost]
    public ActionResult Create(int personId, int courseId)
    {
        var result = _ownershipService.AssignOwnership(courseId, personId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }

    [HttpDelete("{courseId:int}")]
    public ActionResult Delete(int personId, int courseId)
    {
        var result = _ownershipService.RemoveOwnership(courseId, personId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }
}