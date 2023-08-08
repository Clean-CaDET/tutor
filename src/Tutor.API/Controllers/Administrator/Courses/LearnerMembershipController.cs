using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Learning;

namespace Tutor.API.Controllers.Administrator.Courses;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/learners/{learnerId:int}/courses")]
public class LearnerMembershipController : BaseApiController
{
    private readonly IEnrolledCourseService _enrolledCourseService;

    public LearnerMembershipController(IEnrolledCourseService enrolledCourseService)
    {
        _enrolledCourseService = enrolledCourseService;
    }

    [HttpGet]
    public ActionResult<PagedResult<CourseDto>> GetAll(int learnerId, [FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _enrolledCourseService.GetAll(learnerId, page, pageSize);
        return CreateResponse(result);
    }
}