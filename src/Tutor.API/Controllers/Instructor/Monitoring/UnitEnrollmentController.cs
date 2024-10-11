using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Enrollments;
using Tutor.Courses.API.Public.Monitoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring/enrollments")]
public class UnitEnrollmentController : BaseApiController
{
    private readonly IEnrollmentService _enrollmentService;

    public UnitEnrollmentController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    // POST because int[] can have many elements, making the query too long.
    [HttpPost]
    public ActionResult<List<EnrollmentDto>> GetEnrollments([FromBody] UnitAndLearnerIdsDto enrollmentFilter)
    {
        var result = _enrollmentService.GetEnrollments(enrollmentFilter, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPost("{unitId:int}/enroll")]
    public ActionResult<List<EnrollmentDto>> BulkEnroll(int unitId, [FromBody] EnrollmentRequestDto request)
    {
        var result = _enrollmentService.BulkEnroll(unitId, request.LearnerIds, request.NewEnrollment, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPost("{unitId:int}/unenroll")]
    public ActionResult<List<EnrollmentDto>> BulkUnenroll(int unitId, [FromBody] int[] learnerIds)
    {
        var result = _enrollmentService.BulkUnenroll(unitId, learnerIds, User.InstructorId());
        return CreateResponse(result);
    }
}