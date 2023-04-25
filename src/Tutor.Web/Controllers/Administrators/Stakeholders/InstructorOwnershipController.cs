﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Web.Mappings.Knowledge.DTOs;

namespace Tutor.Web.Controllers.Administrators.Stakeholders;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/instructors/{instructorId:int}/ownerships")]
public class InstructorOwnershipController : BaseApiController
{
    private readonly ICourseOwnershipService _ownershipService;

    public InstructorOwnershipController(IMapper mapper, ICourseOwnershipService ownershipService) : base(mapper)
    {
        _ownershipService = ownershipService;
    }

    [HttpGet]
    public ActionResult<List<CourseDto>> GetAll(int instructorId)
    {
        var result = _ownershipService.GetOwnedCourses(instructorId);
        return CreateResponse<Course, CourseDto>(result);
    }

    [HttpPost]
    public ActionResult Create(int instructorId, [FromBody] int courseId)
    {
        var result = _ownershipService.AssignOwnership(courseId, instructorId);
        return CreateResponse<Course, CourseDto>(result);
    }

    [HttpDelete("{courseId:int}")]
    public ActionResult Delete(int instructorId, int courseId)
    {
        var result = _ownershipService.RemoveOwnership(courseId, instructorId);
        return CreateResponse(result);
    }
}