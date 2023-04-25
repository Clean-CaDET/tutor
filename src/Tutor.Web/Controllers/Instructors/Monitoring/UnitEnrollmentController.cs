using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.UseCases.Monitoring;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Enrollments;

namespace Tutor.Web.Controllers.Instructors.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring/enrollments/unit/{unitId:int}")]
public class UnitEnrollmentController : BaseApiController
{
    private readonly IEnrollmentService _enrollmentService;

    public UnitEnrollmentController(IMapper mapper, IEnrollmentService enrollmentService) : base(mapper)
    {
        _enrollmentService = enrollmentService;
    }

    // POST because of int[] that can have 150 elements, making the query too long.
    // A better solution might be to send groupId and 0 or a separate endpoint for All groups, but that clashes with pagination.
    [HttpPost("all")]
    public ActionResult<List<UnitEnrollmentDto>> GetEnrollments(int unitId, [FromBody] int[] learnerIds)
    {
        var result = _enrollmentService.GetEnrollments(unitId, learnerIds, User.InstructorId());
        return CreateResponse<UnitEnrollment, UnitEnrollmentDto>(result);
    }

    [HttpPost("bulk")]
    public ActionResult<List<UnitEnrollmentDto>> BulkEnroll(int unitId, [FromBody] int[] learnerIds)
    {
        var result = _enrollmentService.BulkEnroll(unitId, learnerIds, User.InstructorId());
        return CreateResponse<UnitEnrollment, UnitEnrollmentDto>(result);
    }

    [HttpPost]
    public ActionResult<UnitEnrollmentDto> Enroll(int unitId, [FromBody] int learnerId)
    {
        var result = _enrollmentService.Enroll(unitId, learnerId, User.InstructorId());
        return CreateResponse<UnitEnrollment, UnitEnrollmentDto>(result);
    }

    [HttpDelete("{learnerId:int}")]
    public ActionResult Unenroll(int unitId, int learnerId)
    {
        var result = _enrollmentService.Unenroll(unitId, learnerId, User.InstructorId());
        return CreateResponse(result);
    }
}