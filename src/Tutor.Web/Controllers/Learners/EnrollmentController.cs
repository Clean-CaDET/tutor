using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.UseCases.Monitoring;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Knowledge.DTOs;

namespace Tutor.Web.Controllers.Learners;

[Authorize(Policy = "learnerPolicy")]
[Route("api/enrolled-courses")]
public class EnrollmentController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IEnrollmentService _enrollmentService;

    public EnrollmentController(IMapper mapper,
        IEnrollmentService enrollmentService)
    {
        _mapper = mapper;
        _enrollmentService = enrollmentService;
    }

    [HttpGet]
    public ActionResult<List<CourseDto>> GetEnrolledCourses()
    {
        var result = _enrollmentService.GetEnrolledCourses(User.LearnerId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<CourseDto>).ToList());
    }

    [HttpGet("{courseId:int}")]
    public ActionResult<CourseDto> GetCourseWithEnrolledAndActiveUnits(int courseId)
    {
        var result = _enrollmentService.GetCourseWithEnrolledAndActiveUnits(courseId, User.LearnerId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<CourseDto>(result.Value));
    }
}