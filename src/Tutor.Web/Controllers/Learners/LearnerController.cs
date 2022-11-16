using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.UseCases.StakeholderManagement;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.CourseIteration;
using Tutor.Web.Mappings.Knowledge.DTOs;

namespace Tutor.Web.Controllers.Learners
{
    [Route("api/learners/")]
    [ApiController]
    public class LearnerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILearnerService _learnerService;
        private readonly IAvailableCourseService _availableCourseService;

        public LearnerController(IMapper mapper,
            ILearnerService learnerService,
            IAvailableCourseService availableCourseService)
        {
            _learnerService = learnerService;
            _mapper = mapper;
            _availableCourseService = availableCourseService;
        }

        [HttpGet("profile")]
        public ActionResult<LearnerDto> GetLearnerProfile()
        {
            var result = _learnerService.GetLearnerProfile(User.Id());
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<LearnerDto>(result.Value));
        }

        [HttpGet("courses")]
        public ActionResult<List<CourseDto>> GetEnrolledCourses()
        {
            var result = _availableCourseService.GetEnrolledCourses(User.LearnerId());
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(result.Value.Select(_mapper.Map<CourseDto>).ToList());
        }
    }
}