using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.UseCases.Learning.Assessment;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems;

namespace Tutor.Web.Controllers.Learners.Learning.Assessment
{
    [Authorize(Policy = "learnerPolicy")]
    [Route("api/learning/knowledge-component/{knowledgeComponentId:int}/assessment-item/")]
    public class SelectionController : BaseApiController
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
            if (result.IsFailed) return CreateErrorResponse(result.Errors);
            return Ok(_mapper.Map<AssessmentItemDto>(result.Value));
        }
    }
}