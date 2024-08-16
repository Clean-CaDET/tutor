using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Learning;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner;

[Authorize(Policy = "learnerPolicy")]
[Route("api/enrolled-courses")]
public class EnrolledCourseController : BaseApiController
{
    private readonly IEnrolledCourseService _enrolledCourseService;
    private readonly IUnitProgressService _progressService;

    public EnrolledCourseController(IEnrolledCourseService enrolledCourseService, IUnitProgressService progressService)
    {
        _enrolledCourseService = enrolledCourseService;
        _progressService = progressService;
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

    [HttpPost("{courseId:int}/units/mastered")]
    public ActionResult<List<int>> GetMasteredUnitIds([FromBody] List<int> unitIds)
    {
        var result = _progressService.GetMasteredUnitIds(unitIds, User.LearnerId());
        return CreateResponse(result);
    }
}