using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.LearnerModel.DomainOverlay;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;
using Tutor.Infrastructure.Security.Authorization.JWT;
using Tutor.Web.Controllers.Domain.DTOs;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalItems;

namespace Tutor.Web.Controllers.Domain
{
    [Authorize(Policy = "learnerPolicy")]
    [Route("api/units/")]
    [ApiController]
    public class DomainOverlayController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IKcMasteryService _kcMasteryService;

        public DomainOverlayController(IMapper mapper, IKcMasteryService kcMasteryService)
        {
            _mapper = mapper;
            _kcMasteryService = kcMasteryService;
        }

        [HttpGet]
        public ActionResult<List<UnitDto>> GetUnits()
        {
            var result = _kcMasteryService.GetUnits(User.Id());
            return Ok(result.Value.Select(u => _mapper.Map<UnitDto>(u)).ToList());
        }

        [HttpGet("{unitId:int}")]
        public ActionResult<List<UnitDto>> GetUnit(int unitId)
        {
            var result = _kcMasteryService.GetUnit(unitId, User.Id());
            if (result.IsFailed) return NotFound(result.Errors);

            var unitDto = _mapper.Map<UnitDto>(result.Value);
            AppendMasteriesToResponse(unitDto, User.Id());

            return Ok(unitDto);
        }

        private void AppendMasteriesToResponse(UnitDto unitDto, int learnerId)
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
            var result = _kcMasteryService.GetKnowledgeComponent(knowledgeComponentId, User.Id());
            if (result.IsSuccess) return Ok(_mapper.Map<KnowledgeComponentDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpGet("knowledge-components/{knowledgeComponentId:int}/instructional-items/")]
        public ActionResult<List<InstructionalItemDto>> GetInstructionalItems(int knowledgeComponentId)
        {
            var result = _kcMasteryService.GetInstructionalItems(knowledgeComponentId, User.Id());
            return Ok(result.Value.Select(ie => _mapper.Map<InstructionalItemDto>(ie)).ToList());
        }

        [HttpGet("knowledge-component/{knowledgeComponentId:int}/assessment-item/")]
        public ActionResult<AssessmentItemDto> GetSuitableAssessmentItem(int knowledgeComponentId)
        {
            var result = _kcMasteryService.SelectSuitableAssessmentItem(knowledgeComponentId, User.Id());
            if (result.IsSuccess) return Ok(_mapper.Map<AssessmentItemDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpGet("knowledge-components/statistics/{knowledgeComponentId:int}")]
        public ActionResult<KnowledgeComponentStatisticsDto> GetKnowledgeComponentStatistics(int knowledgeComponentId)
        {
            var result = _kcMasteryService.GetKnowledgeComponentStatistics(knowledgeComponentId, User.Id());
            if (result.IsSuccess) return Ok(_mapper.Map<KnowledgeComponentStatisticsDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpPost("knowledge-components/{knowledgeComponentId:int}/session/launch")]
        public ActionResult LaunchSession(int knowledgeComponentId)
        {
            var result = _kcMasteryService.LaunchSession(knowledgeComponentId, User.Id());
            if (result.IsSuccess) return Ok();
            return BadRequest(result.Errors);
        }

        [HttpPost("knowledge-components/{knowledgeComponentId:int}/session/terminate")]
        public ActionResult TerminateSession(int knowledgeComponentId)
        {
            var result = _kcMasteryService.TerminateSession(knowledgeComponentId, User.Id());
            if (result.IsSuccess) return Ok();
            return BadRequest(result.Errors);
        }
    }
}