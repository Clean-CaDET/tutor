using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.DomainModel;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.KnowledgeComponentEvents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.SessionLifecycleEvents;
using Tutor.Infrastructure.Database.EventStore;

namespace Tutor.Web.Controllers.Analytics
{
    [Authorize(Policy = "instructorPolicy")]
    [Route("api/analytics/")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly ILearnerRepository _learnerRepository;
        private readonly IDomainRepository _domainRepository;
        private readonly IEventStore _eventStore;
        private readonly IMapper _mapper;

        public AnalyticsController(ILearnerRepository learnerRepository, IDomainRepository domainRepository, IEventStore eventStore, IMapper mapper)
        {
            _learnerRepository = learnerRepository;
            _domainRepository = domainRepository;
            _eventStore = eventStore;
            _mapper = mapper;
        }

        [HttpGet("learner-progress")]
        public ActionResult<PagedResult<LearnerProgressDto>> GetProgress([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] int groupId)
        {
            var task = _learnerRepository.GetLearnersWithMasteriesAsync(page, pageSize, groupId);
            task.Wait();
            var results = task.Result.Results.Select(progress => _mapper.Map<LearnerProgressDto>(progress)).ToList();
            return Ok(new PagedResult<LearnerProgressDto>(results, task.Result.TotalCount));
        }

        [HttpGet("kc-statistics")]
        public ActionResult<List<KcStatisticsDto>> GetKcStatistics([FromQuery] int unitId, [FromQuery] int groupId)
        {
            // Should refactor. Need to research appropriate patterns for this case. AnalyticsService seems to be a simple solution.
            var unit = _domainRepository.GetUnit(unitId);
            var learnerIds = _learnerRepository.GetByGroupId(groupId).Select(l => l.Id).ToList();

            var events = _eventStore.GetKcEvents(unit.KnowledgeComponents.Select(kc => kc.Id).ToList(), learnerIds);
            
            return Ok(CalculateKcStatistics(unit, events));
        }

        private static List<KcStatisticsDto> CalculateKcStatistics(KnowledgeUnit unit, List<KnowledgeComponentEvent> events)
        {
            return unit.KnowledgeComponents.Select(kc =>
                new KcStatisticsDto
                {
                    KcCode = kc.Code,
                    KcName = kc.Name,
                    TotalStarted = events.Where(e => e is SessionLaunched && e.KnowledgeComponentId == kc.Id).Select(e => e.LearnerId).Distinct().Count(),
                    TotalCompleted = events.Where(e => e is KnowledgeComponentCompleted && e.KnowledgeComponentId == kc.Id).Select(e => e.LearnerId).Distinct().Count(),
                    TotalPassed = events.Where(e => e is KnowledgeComponentPassed && e.KnowledgeComponentId == kc.Id).Select(e => e.LearnerId).Distinct().Count()
                }
            ).ToList();
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
