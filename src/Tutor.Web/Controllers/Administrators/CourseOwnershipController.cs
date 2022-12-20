using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Web.Mappings.Knowledge.DTOs;

namespace Tutor.Web.Controllers.Administrators;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/instructors/{instructorId:int}/ownerships")]
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
    public ActionResult<List<CourseDto>> GetAll(int instructorId)
    {
        var result = _ownershipService.GetOwnedCourses(instructorId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<CourseDto>).ToList());
    }

    [HttpPost]
    public ActionResult Create(int instructorId, [FromBody] int courseId)
    {
        var result = _ownershipService.AssignOwnership(courseId, instructorId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<CourseDto>(result.Value));
    }

    [HttpDelete("{courseId:int}")]
    public ActionResult Delete(int instructorId, int courseId)
    {
        var result = _ownershipService.RemoveOwnership(courseId, instructorId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }
}