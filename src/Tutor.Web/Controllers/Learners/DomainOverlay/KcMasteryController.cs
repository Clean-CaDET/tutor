using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.UseCases.Learning;
using Tutor.Core.UseCases.Learning.Assessment;
using Tutor.Core.UseCases.Learning.Statistics;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Domain.DTOs;
using Tutor.Web.Mappings.Domain.DTOs.AssessmentItems;
using Tutor.Web.Mappings.Domain.DTOs.InstructionalItems;
using Tutor.Web.Mappings.Mastery;

namespace Tutor.Web.Controllers.Learners.DomainOverlay
{
    [Authorize(Policy = "learnerPolicy")]
    [Route("api/units/")]
    [ApiController]
    public class KcMasteryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IKcMasteryService _kcMasteryService;
        private readonly IStatisticsService _learningStatisticsService;
        private readonly ISelectionService _assessmentSelectionService;

        public KcMasteryController(IMapper mapper, IKcMasteryService kcMasteryService, IStatisticsService learningStatisticsService, ISelectionService assessmentSelectionService)
        {
            _mapper = mapper;
            _kcMasteryService = kcMasteryService;
            _learningStatisticsService = learningStatisticsService;
            _assessmentSelectionService = assessmentSelectionService;
        }

        [HttpGet]
        public ActionResult<List<KnowledgeUnitDto>> GetUnits()
        {
            var result = _kcMasteryService.GetUnits(User.LearnerId());
            return Ok(result.Value.Select(u => _mapper.Map<KnowledgeUnitDto>(u)).ToList());
        }

        [HttpGet("{unitId:int}")]
        public ActionResult<KnowledgeUnitDto> GetUnit(int unitId)
        {
            var result = _kcMasteryService.GetUnit(unitId, User.LearnerId());
            if (result.IsFailed) return NotFound(result.Errors);

            var unitDto = _mapper.Map<KnowledgeUnitDto>(result.Value);
            AppendMasteriesToResponse(unitDto, User.LearnerId());

            return Ok(unitDto);
        }

        private void AppendMasteriesToResponse(KnowledgeUnitDto unitDto, int learnerId)
        {
            var kcIds = GetKcIds(unitDto.KnowledgeComponents);
            var masteries = _kcMasteryService.GetKnowledgeComponentMasteries(kcIds, learnerId).Value;
            PopulateMasteries(unitDto.KnowledgeComponents, masteries);
        }

        private static List<int> GetKcIds(List<KnowledgeComponentDto> knowledgeComponents)
        {
            var kcIds = new List<int>();
            foreach (var k in knowledgeComponents)
            {
                kcIds.Add(k.Id);
                kcIds.AddRange(GetKcIds(k.KnowledgeComponents));
            }

            return kcIds;
        }

        private static void PopulateMasteries(List<KnowledgeComponentDto> kcs, List<KnowledgeComponentMastery> masteries)
        {
            foreach (var kc in kcs)
            {
                var mastery = masteries.Find(m => m.KnowledgeComponent.Id == kc.Id);
                kc.Mastery = new KnowledgeComponentMasteryDto { Mastery = mastery.Mastery, IsSatisfied = mastery.IsSatisfied };
                PopulateMasteries(kc.KnowledgeComponents, masteries);
            }
        }

        [HttpGet("knowledge-components/{knowledgeComponentId:int}")]
        public ActionResult<KnowledgeComponentDto> GetKnowledgeComponent(int knowledgeComponentId)
        {
            var result = _kcMasteryService.GetKnowledgeComponent(knowledgeComponentId, User.LearnerId());
            if (result.IsSuccess) return Ok(_mapper.Map<KnowledgeComponentDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpGet("knowledge-components/{knowledgeComponentId:int}/instructional-items/")]
        public ActionResult<List<InstructionalItemDto>> GetInstructionalItems(int knowledgeComponentId)
        {
            var result = _kcMasteryService.GetInstructionalItems(knowledgeComponentId, User.LearnerId());
            return Ok(result.Value.Select(ie => _mapper.Map<InstructionalItemDto>(ie)).ToList());
        }

        [HttpGet("knowledge-component/{knowledgeComponentId:int}/assessment-item/")]
        public ActionResult<AssessmentItemDto> GetSuitableAssessmentItem(int knowledgeComponentId)
        {
            var result = _assessmentSelectionService.SelectSuitableAssessmentItem(knowledgeComponentId, User.LearnerId());
            if (result.IsSuccess) return Ok(_mapper.Map<AssessmentItemDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpGet("knowledge-components/statistics/{knowledgeComponentId:int}")]
        public ActionResult<KcMasteryStatisticsDto> GetKcMasteryStatistics(int knowledgeComponentId)
        {
            var result = _learningStatisticsService.GetKcMasteryStatistics(knowledgeComponentId, User.LearnerId());
            if (result.IsSuccess) return Ok(_mapper.Map<KcMasteryStatisticsDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpPost("knowledge-components/{knowledgeComponentId:int}/session/launch")]
        public ActionResult LaunchSession(int knowledgeComponentId)
        {
            var result = _kcMasteryService.LaunchSession(knowledgeComponentId, User.LearnerId());
            if (result.IsSuccess) return Ok();
            return BadRequest(result.Errors);
        }

        [HttpPost("knowledge-components/{knowledgeComponentId:int}/session/terminate")]
        public ActionResult TerminateSession(int knowledgeComponentId)
        {
            var result = _kcMasteryService.TerminateSession(knowledgeComponentId, User.LearnerId());
            if (result.IsSuccess) return Ok();
            return BadRequest(result.Errors);
        }
    }
}