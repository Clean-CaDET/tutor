using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Learning;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner;

[Authorize(Policy = "learnerPolicy")]
[Route("api/enrolled-courses")]
public class EnrolledCourseController : BaseApiController
{
    private readonly IEnrolledCourseService _enrolledCourseService;

    public EnrolledCourseController(IEnrolledCourseService enrolledCourseService)
    {
        _enrolledCourseService = enrolledCourseService;
    }

    [HttpGet]
    public ActionResult<PagedResult<CourseDto>> GetEnrolledCourses([FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _enrolledCourseService.GetAll(User.LearnerId(), page, pageSize);
        return CreateResponse(result);
    }

    [HttpGet("{courseId:int}")]
    public ActionResult<CourseDto> GetCourseWithEnrolledAndActiveUnits(int courseId)
    {
        var result = _enrolledCourseService.GetWithActiveUnits(courseId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpGet("{courseId:int}/units/{unitId:int}")]
    public ActionResult<KnowledgeUnitDto> GetEnrolledAndActiveUnit(int unitId)
    {
        var result = _enrolledCourseService.GetUnit(unitId, User.LearnerId());
        return CreateResponse(result);
    }
}