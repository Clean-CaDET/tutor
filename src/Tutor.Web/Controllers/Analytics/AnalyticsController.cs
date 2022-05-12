using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.LearnerModel;
using Tutor.Infrastructure.Database.EventStore;

namespace Tutor.Web.Controllers.Analytics
{
    [Authorize(Policy = "instructorPolicy")]
    [Route("api/analytics/")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly ILearnerRepository _learnerRepository;
        private readonly IEventStore _eventStore;
        private readonly IMapper _mapper;

        public AnalyticsController(ILearnerRepository learnerRepository, IEventStore eventStore, IMapper mapper)
        {
            _learnerRepository = learnerRepository;
            _eventStore = eventStore;
            _mapper = mapper;
        }

        [HttpGet("learner-progress")]
        public ActionResult<PagedResult<LearnerProgressDto>> GetProgress([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] int groupId)
        {
            var task = _learnerRepository.GetLearnersAsync(page, pageSize, groupId);
            task.Wait();
            var results = task.Result.Results.Select(progress => _mapper.Map<LearnerProgressDto>(progress)).ToList();
            return Ok(new PagedResult<LearnerProgressDto>(results, task.Result.TotalCount));
        }

        [HttpGet("events")]
        public ActionResult<PagedResult<DomainEvent>> GetEvents([FromQuery] int page, [FromQuery] int pageSize)
        {
            var task = _eventStore.GetEventsAsync(page, pageSize);
            task.Wait();
            return Ok(task.Result);
        }
    }
}
