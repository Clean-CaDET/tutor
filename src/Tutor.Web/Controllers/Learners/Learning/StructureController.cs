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
    [Route("api/learning")]
    public class StructureController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IStructureService _learningStructureService;
        // Discuss how to structure Course-Unit-KC endpoints and services
        public StructureController(IMapper mapper, IStructureService learningStructureService)
        {
            _mapper = mapper;
            _learningStructureService = learningStructureService;
        }

        [HttpGet("units/{unitId:int}")]
        public ActionResult<KnowledgeUnitDto> GetUnit(int unitId)
        {
            var result = _learningStructureService.GetUnit(unitId, User.LearnerId());
            if (result.IsFailed) return CreateErrorResponse(result.Errors);

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
                var mastery = masteries.Find(m => m.KnowledgeComponentId == kc.Id);
                kc.Mastery = new KnowledgeComponentMasteryDto { Mastery = mastery.Mastery, IsSatisfied = mastery.IsSatisfied };
                PopulateMasteries(kc.KnowledgeComponents, masteries);
            }
        }
        
        [HttpGet("knowledge-component/{knowledgeComponentId:int}/")]
        public ActionResult<KnowledgeComponentDto> GetKnowledgeComponent(int knowledgeComponentId)
        {
            var result = _learningStructureService.GetKnowledgeComponent(knowledgeComponentId, User.LearnerId());
            if(result.IsFailed) return CreateErrorResponse(result.Errors);
            return Ok(_mapper.Map<KnowledgeComponentDto>(result.Value));
        }

        [HttpGet("knowledge-component/{knowledgeComponentId:int}/instructional-items/")]
        public ActionResult<List<InstructionalItemDto>> GetInstructionalItems(int knowledgeComponentId)
        {
            var result = _learningStructureService.GetInstructionalItems(knowledgeComponentId, User.LearnerId());
            if (result.IsFailed) return CreateErrorResponse(result.Errors);
            return Ok(result.Value.Select(_mapper.Map<InstructionalItemDto>).ToList());
        }
    }
}