using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.UseCases.StakeholderManagement;
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
        private readonly ICourseService _courseService;
        private readonly IKnowledgeUnitRepository _knowledgeUnitRepository;

        public LearnerController(ILearnerService learnerService, IMapper mapper,
            ICourseService courseService, IKnowledgeUnitRepository knowledgeUnitRepository)
        {
            _learnerService = learnerService;
            _mapper = mapper;
            _courseService = courseService;
            _knowledgeUnitRepository = knowledgeUnitRepository;
        }

        [HttpGet("profile")]
        public ActionResult<LearnerDto> GetLearnerProfile()
        {
            var result = _learnerService.GetLearnerProfile(User.Id());
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<LearnerDto>(result.Value));
        }

        [HttpGet("courses")]
        public ActionResult<List<CourseDto>> GetCoursesByLearner()
        {
            var result = _courseService.GetEnrolledCourses(User.LearnerId());
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(result.Value.Select(c => _mapper.Map<CourseDto>(c)).ToList());
        }
        
        [HttpGet("units/{courseId}")]
        public ActionResult<List<KnowledgeUnitDto>> GetUnitsByEnrollmentStatus(int courseId)
        {
            var result = _knowledgeUnitRepository.GetActiveUnits(courseId, User.Id());
            return Ok(result.Select(u => _mapper.Map<KnowledgeUnitDto>(u)).ToList());
        }
    }
}