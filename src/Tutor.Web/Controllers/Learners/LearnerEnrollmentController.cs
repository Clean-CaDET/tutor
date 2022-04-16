using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.LearnerModel;
using Tutor.Web.Controllers.Learners.DTOs;

namespace Tutor.Web.Controllers.Learners
{
    [Authorize(Policy = "administratorPolicy")]
    [Route("api/enrollment/")]
    [ApiController]
    public class LearnerEnrollmentController : ControllerBase
    {
        private readonly ILearnerService _enrollmentService;

        public LearnerEnrollmentController(ILearnerService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost]
        public ActionResult Enroll([FromBody] UnitEnrollmentDto enrollmentDto)
        {
            var result = _enrollmentService.Enroll(enrollmentDto.LearnerId, enrollmentDto.UnitId);
            if(result.IsSuccess) return Ok();
            return NotFound();
        }
    }
}
