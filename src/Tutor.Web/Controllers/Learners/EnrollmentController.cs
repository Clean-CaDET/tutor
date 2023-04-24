using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.Structure;
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
        return CreateResponse<Course, CourseDto>(result, Ok, CreateErrorResponse, _mapper);
    }

    [HttpGet("{courseId:int}")]
    public ActionResult<CourseDto> GetCourseWithEnrolledAndActiveUnits(int courseId)
    {
        var result = _enrollmentService.GetCourseWithEnrolledAndActiveUnits(courseId, User.LearnerId());
        return CreateResponse<Course, CourseDto>(result, Ok, CreateErrorResponse, _mapper);
    }
}