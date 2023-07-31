using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Monitoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring/enrollments/unit/{unitId:int}")]
public class UnitEnrollmentController : BaseApiController
{
    private readonly IEnrollmentService _enrollmentService;

    public UnitEnrollmentController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    // POST because of int[] that can have 150 elements, making the query too long.
    // A better solution might be to send groupId and 0 or a separate endpoint for All groups, but that clashes with pagination.
    [HttpPost("all")]
    public ActionResult<List<UnitEnrollmentDto>> GetEnrollments(int unitId, [FromBody] int[] learnerIds)
    {
        var result = _enrollmentService.GetEnrollments(unitId, learnerIds, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPost("bulk")]
    public ActionResult<List<UnitEnrollmentDto>> BulkEnroll(int unitId, [FromBody] EnrollmentRequestDto request)
    {
        var result = _enrollmentService.BulkEnroll(unitId, request.LearnerIds, request.Start, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult<UnitEnrollmentDto> Enroll(int unitId, [FromBody] EnrollmentRequestDto request)
    {
        var result = _enrollmentService.Enroll(unitId, request.LearnerIds[0], request.Start, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpDelete("{learnerId:int}")]
    public ActionResult Unenroll(int unitId, int learnerId)
    {
        var result = _enrollmentService.Unenroll(unitId, learnerId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPost("bulk-unenroll")]
    public ActionResult<List<UnitEnrollmentDto>> BulkUnenroll(int unitId, [FromBody] int[] learnerIds)
    {
        var result = _enrollmentService.BulkUnenroll(unitId, learnerIds, User.InstructorId());
        return CreateResponse(result);
    }
}