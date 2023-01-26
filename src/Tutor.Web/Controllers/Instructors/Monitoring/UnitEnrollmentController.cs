using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.UseCases.Monitoring;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Enrollments;

namespace Tutor.Web.Controllers.Instructors.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring/enrollments/unit/{unitId:int}")]
public class UnitEnrollmentController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IEnrollmentService _enrollmentService;

    public UnitEnrollmentController(IMapper mapper, IEnrollmentService enrollmentService)
    {
        _mapper = mapper;
        _enrollmentService = enrollmentService;
    }

    // POST because of int[] that can have 150 elements, making the query too long.
    [HttpPost("all")]
    public ActionResult<List<UnitEnrollmentDto>> GetEnrollments(int unitId, [FromBody] int[] learnerIds)
    {
        var result = _enrollmentService.GetEnrollments(unitId, learnerIds, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<UnitEnrollmentDto>).ToList());
    }

    [HttpPost("bulk")]
    public ActionResult<List<UnitEnrollmentDto>> BulkEnroll(int unitId, [FromBody] int[] learnerIds)
    {
        var result = _enrollmentService.BulkEnroll(unitId, learnerIds, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<UnitEnrollmentDto>).ToList());
    }

    [HttpPost]
    public ActionResult<UnitEnrollmentDto> Enroll(int unitId, [FromBody] int learnerId)
    {
        var result = _enrollmentService.Enroll(unitId, learnerId, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<UnitEnrollmentDto>(result.Value));
    }

    [HttpDelete("{learnerId:int}")]
    public ActionResult Unenroll(int unitId, int learnerId)
    {
        var result = _enrollmentService.Unenroll(unitId, learnerId, User.InstructorId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }
}