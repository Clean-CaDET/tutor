using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

    // POST because of int[] that can have 150 elements, making the query too long.
    // A better solution might be to send groupId and 0 or a separate endpoint for All groups, but that clashes with pagination.
    [HttpPost]
    public ActionResult<List<EnrollmentDto>> GetEnrollments([FromBody] EnrollmentFilterDto unitAndLearnerIds)
    {
        var result = _enrollmentService.GetEnrollments(unitAndLearnerIds, User.InstructorId());
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