using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.UseCases.Monitoring;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Knowledge.DTOs;

namespace Tutor.Web.Controllers.Learners;

[Authorize(Policy = "learnerPolicy")]
[Route("api/enrolled-courses")]
public class EnrollmentController : BaseApiController
{
    private readonly IEnrollmentService _enrollmentService;

    public EnrollmentController(IMapper mapper, IEnrollmentService enrollmentService) : base(mapper)
    {
        _enrollmentService = enrollmentService;
    }

    [HttpGet]
    public ActionResult<PagedResult<CourseDto>> GetEnrolledCourses([FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _enrollmentService.GetEnrolledCourses(User.LearnerId(), page, pageSize);
        return CreateResponse<Course, CourseDto>(result);
    }

    [HttpGet("{courseId:int}")]
    public ActionResult<CourseDto> GetCourseWithEnrolledAndActiveUnits(int courseId)
    {
        var result = _enrollmentService.GetCourseWithEnrolledAndActiveUnits(courseId, User.LearnerId());
        return CreateResponse<Course, CourseDto>(result);
    }
}