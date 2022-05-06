using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.LearnerModel;

namespace Tutor.Web.Controllers.Analytics
{
    [Authorize(Policy = "instructorPolicy")]
    [Route("api/analytics/learner-progress")]
    [ApiController]
    public class LearnerProgressController : ControllerBase
    {
        private readonly ILearnerRepository _learnerRepository;
        private readonly IMapper _mapper;

        public LearnerProgressController(ILearnerRepository learnerRepository, IMapper mapper)
        {
            _learnerRepository = learnerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<PagedResult<LearnerProgressDto>> GetEvents([FromQuery] int page, [FromQuery] int pageSize)
        {
            var task = _learnerRepository.GetLearnersWithMasteriesAsync(page, pageSize);
            task.Wait();
            var results = task.Result.Results.Select(progress => _mapper.Map<LearnerProgressDto>(progress)).ToList();
            return Ok(new PagedResult<LearnerProgressDto>(results, task.Result.TotalCount));
        }
    }
}
