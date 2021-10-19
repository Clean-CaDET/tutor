using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.Exceptions;
using Tutor.Core.LearnerModel.Learners;
using Tutor.Web.Controllers.Learners.DTOs;
using Tutor.Web.Security.IAM;

namespace Tutor.Web.Controllers.Learners
{
    [Route("api/learners/")]
    [ApiController]
    public class LearnerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILearnerService _learnerService;
        private readonly IAuthProvider _authProvider;

        public LearnerController(IMapper mapper, ILearnerService learnerService, IAuthProvider authProvider)
        {
            _mapper = mapper;
            _learnerService = learnerService;
            _authProvider = authProvider;
        }

        [HttpPost("register")]
        public async Task<ActionResult<LearnerDTO>> Register([FromBody] LearnerDTO learnerDto)
        {
            var learner = _mapper.Map<Learner>(learnerDto);

            if (bool.Parse(Environment.GetEnvironmentVariable("KEYCLOAK_ON") ?? "false"))
            {
                learner = await _authProvider.Register(learner);
            }

            var registeredLearner = _learnerService.Register(learner);
            return Ok(_mapper.Map<LearnerDTO>(registeredLearner));
        }

        [HttpPost("login")]
        public ActionResult<LearnerDTO> Login([FromBody] LoginDTO login)
        {
            try
            {
                var learner = _learnerService.Login(login.StudentIndex);
                return Ok(_mapper.Map<LearnerDTO>(learner));
            }
            catch (LearnerWithStudentIndexNotFound e)
            {
                return NotFound(e.Message);
            }
        }
    }
}