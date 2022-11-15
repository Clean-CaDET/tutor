using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.UseCases.Learning.Assessment;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems;

namespace Tutor.Web.Controllers.Learners.Learning.Assessment
{
    [Authorize(Policy = "learnerPolicy")]
    [Route("api/knowledge-component/{knowledgeComponentId:int}/assessment-item/")]
    [ApiController]
    public class SelectionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISelectionService _assessmentSelectionService;

        public SelectionController(IMapper mapper, ISelectionService assessmentSelectionService)
        {
            _mapper = mapper;
            _assessmentSelectionService = assessmentSelectionService;
        }

        [HttpGet]
        public ActionResult<AssessmentItemDto> GetSuitableAssessmentItem(int knowledgeComponentId)
        {
            var result = _assessmentSelectionService.SelectSuitableAssessmentItem(knowledgeComponentId, User.LearnerId());
            if (result.IsSuccess) return Ok(_mapper.Map<AssessmentItemDto>(result.Value));
            return NotFound(result.Errors);
        }
    }
}