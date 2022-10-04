using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.DomainModel;
using Tutor.Core.EnrollmentModel;
using Tutor.Core.LearnerModel;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Domain.DTOs;
using Tutor.Web.Mappings.Enrollments;

namespace Tutor.Web.Controllers.Learners
{
    [Route("api/learners/")]
    [ApiController]
    public class LearnerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILearnerService _learnerService;
        private readonly ICourseRepository _courseRepository;

        public LearnerController(ILearnerService learnerService, IMapper mapper, ICourseRepository courseRepository)
        {
            _learnerService = learnerService;
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        [HttpGet("profile")]
        public ActionResult<LearnerDto> GetLearnerProfile()
        {
            var result = _learnerService.GetLearnerProfile(User.Id());
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<LearnerDto>(result.Value));
        }

        [HttpGet("groups")]
        public ActionResult<LearnerGroup> GetGroups()
        {
            var result = _learnerService.GetGroups();
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(result.Value);
        }
        
        [HttpGet("courses")]
        public ActionResult<List<CourseDto>> GetCoursesByLearner()
        {
            var result = _courseRepository.GetCoursesByLearner(User.LearnerId());
            return Ok(result.Select(c => _mapper.Map<CourseDto>(c)).ToList());
        }
    }
}