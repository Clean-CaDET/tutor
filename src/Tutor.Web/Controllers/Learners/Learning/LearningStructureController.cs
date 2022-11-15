using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.UseCases.Learning;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Tutor.Web.Mappings.Knowledge.DTOs.InstructionalItems;
using Tutor.Web.Mappings.KnowledgeMastery;

namespace Tutor.Web.Controllers.Learners.Learning
{
    [Authorize(Policy = "learnerPolicy")]
    [Route("api/learners/courses/{courseId:int}/")]
    [ApiController]
    public class LearningStructureController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStructureService _learningStructureService;
        // Discuss how to structure Course-Unit-KC endpoints and services
        public LearningStructureController(IMapper mapper, IStructureService learningStructureService)
        {
            _mapper = mapper;
            _learningStructureService = learningStructureService;
        }

        [HttpGet]
        public ActionResult<List<KnowledgeUnitDto>> GetUnits(int courseId)
        {
            var result = _learningStructureService.GetUnits(courseId, User.LearnerId());
            return Ok(result.Value.Select(u => _mapper.Map<KnowledgeUnitDto>(u)).ToList());
        }

        [HttpGet("units/{unitId:int}/")]
        public ActionResult<KnowledgeUnitDto> GetUnit(int unitId)
        {
            var result = _learningStructureService.GetUnit(unitId, User.LearnerId());
            if (result.IsFailed) return NotFound(result.Errors);

            var unitDto = _mapper.Map<KnowledgeUnitDto>(result.Value);
            AppendMasteriesToResponse(unitDto, User.LearnerId());

            return Ok(unitDto);
        }
        // Should create some form of unit statistics or another endpoint for retriving KCM statistics for the given ID
        private void AppendMasteriesToResponse(KnowledgeUnitDto unitDto, int learnerId)
        {
            var kcIds = GetKcIds(unitDto.KnowledgeComponents);
            var masteries = _learningStructureService.GetKnowledgeComponentMasteries(kcIds, learnerId).Value;
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
        
        [HttpGet("knowledge-component/{knowledgeComponentId}/")]
        public ActionResult<KnowledgeComponentDto> GetKnowledgeComponent(int knowledgeComponentId)
        {
            var result = _learningStructureService.GetKnowledgeComponent(knowledgeComponentId, User.LearnerId());
            if (result.IsSuccess) return Ok(_mapper.Map<KnowledgeComponentDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpGet("knowledge-component/{knowledgeComponentId}/instructional-items/")]
        public ActionResult<List<InstructionalItemDto>> GetInstructionalItems(int knowledgeComponentId)
        {
            var result = _learningStructureService.GetInstructionalItems(knowledgeComponentId, User.LearnerId());
            return Ok(result.Value.Select(ie => _mapper.Map<InstructionalItemDto>(ie)).ToList());
        }
    }
}